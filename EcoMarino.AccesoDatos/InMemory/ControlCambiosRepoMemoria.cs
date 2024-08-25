using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class ControlCambiosRepoMemoria : IRepositorioCambios
    {
        private static List<ControlCambios> _cambios = new List<ControlCambios>();

        public ControlCambiosRepoMemoria()
        {

        }
        public void Add(ControlCambios obj)
        {
            try
            {
                //obj.Validar();
                _cambios.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ControlCambios obj)
        {
            throw new NotImplementedException();
        }

        public List<ControlCambios> FindAll()
        {
            return _cambios;
        }

        public ControlCambios FindById(int id)
        {
            ControlCambios unCambio = null;
            foreach(ControlCambios c in _cambios)
            {
                if(c.Id == id)
                {
                    unCambio = c;
                }
            }
            return unCambio;
        }

        public void Update(ControlCambios obj)
        {
            throw new NotImplementedException();
        }
    }
}
