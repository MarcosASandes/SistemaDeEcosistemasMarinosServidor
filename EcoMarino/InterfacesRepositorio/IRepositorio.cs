using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        public List<T> FindAll();
        public T FindById(int id);
        public void Add(T obj);
        public void Delete(T obj);
        public void Update(T obj);
    }
}
