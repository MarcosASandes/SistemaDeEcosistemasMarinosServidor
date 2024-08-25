using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class EstadoConservacionRepoMemoria : IRepositorioEstadoConservacion
    {
        private static List<EstadoConservacion> _estados = new List<EstadoConservacion>();

        public EstadoConservacionRepoMemoria()
        {

        }
        public void Add(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public List<EstadoConservacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public EstadoConservacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public EstadoConservacion FindByNivelConservacion(int nivel)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
