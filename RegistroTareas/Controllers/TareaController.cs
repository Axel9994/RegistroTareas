using RegistroTareas.Models;
using RegistroTareas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace RegistroTareas.Controllers
{
    public class TareaController : Controller
    {
        private TareaRepository repository;

        public TareaController()
        {
            repository = new TareaRepository();
        }

        // GET: Tarea
        public ActionResult Index(string busqueda, int? pagina)
        {
            pagina = (pagina ?? 1);
            ViewBag.pagina = pagina;
            ViewBag.busqueda = busqueda;

            var lista_tareas = repository.Get(busqueda, pagina);

            return View(lista_tareas);
        }

        // GET: Tarea/Details/5
        public ActionResult Details(int id)
        {
            var tarea = repository.GetById(id);
            return View(tarea);
        }

        // GET: Tarea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarea/Create
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                if (repository.Add(tarea))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "No se creo la tarea");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "No se creo la tarea");
                return View();
            }
        }

        // GET: Tarea/Edit/5
        public ActionResult Edit(int id)
        {
            var tarea = repository.GetById(id);
            return View(tarea);
        }

        // POST: Tarea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tarea tarea)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (repository.Edit(tarea, id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "No se edito la tarea");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "No se edito la tarea");
                return View();
            }
        }

        // GET: Tarea/Delete/5
        public ActionResult Delete(int id)
        {
            var tarea = repository.GetById(id);
            return View(tarea);
        }

        // POST: Tarea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tarea tarea)
        {
            // TODO: Add delete logic here
            if (repository.Remove(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "No se elimino la tarea");
                return View();
            }
        }
    }
}
