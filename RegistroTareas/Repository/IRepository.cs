using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace RegistroTareas.Repository
{
    interface IRepository<T>
    {
        IPagedList<T> Get(string busqueda, int? pagina);
        T GetById(int Id);
        bool Add(T objeto);
        bool Edit(T objeto, int Id);
        bool Remove(int Id);
    }
}
