using RegistroTareas.Context;
using RegistroTareas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PagedList;


namespace RegistroTareas.Repository
{
    public class TareaRepository : IRepository<Tarea>
    {

        private ApplicationDbContext context;
        private static int tamano_pagina = 3;

        public TareaRepository()
        {
            context = new ApplicationDbContext();
        }

        public bool Add(Tarea objeto)
        {
            using(DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(objeto).State = EntityState.Added;
                    context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Edit(Tarea objeto, int Id)
        {
            var tarea = context.Tareas.Where(x => x.Id == Id).FirstOrDefault();
            if (tarea != null)
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(tarea).State = EntityState.Detached;
                        context.Entry(objeto).State = EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }

        public IPagedList<Tarea> Get(string busqueda, int? pagina)
        {
            try
            {
                if (!string.IsNullOrEmpty(busqueda))
                {
                    return context.Tareas.Where(x => x.Nombre.Contains(busqueda) || x.Descripcion.Contains(busqueda))
                        .OrderBy(x => x.Fecha_Entrega)
                        .ToPagedList((int)pagina, tamano_pagina);
                }
                else
                {
                    return context.Tareas.OrderBy(x => x.Fecha_Entrega)
                        .ToPagedList((int)pagina, tamano_pagina);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Tarea GetById(int Id)
        {
            try
            {
                return context.Tareas.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Remove(int Id)
        {
            var tarea = context.Tareas.Where(x => x.Id == Id).FirstOrDefault();
            if (tarea != null)
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(tarea).State = EntityState.Deleted;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}