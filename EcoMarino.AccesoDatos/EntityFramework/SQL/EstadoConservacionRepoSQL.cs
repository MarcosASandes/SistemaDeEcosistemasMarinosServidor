using EcoMarino.Entidades;
using EcoMarino.Enum;
using EcoMarino.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class EstadoConservacionRepoSQL : IRepositorioEstadoConservacion
    {
        private EcoMarinoContext _context { get; set; }

        public EstadoConservacionRepoSQL()
        {
            _context = new EcoMarinoContext();
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
            return _context.EstadosDeConservacion.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public EstadoConservacion FindByNivelConservacion(int nivel)
        {
            EstadoConservacion estadoEncontrado = _context.EstadosDeConservacion.AsNoTracking().Where(e => e.Nombre == NombreEstadoEnum.Deficiente).FirstOrDefault();

            if (nivel >= 95)
            {
                estadoEncontrado = _context.EstadosDeConservacion.AsNoTracking().Where(e => e.Nombre == NombreEstadoEnum.Optimo).FirstOrDefault();
            }
            else if(nivel >= 60)
            {
                estadoEncontrado = _context.EstadosDeConservacion.AsNoTracking().Where(e => e.Nombre == NombreEstadoEnum.Aceptable).FirstOrDefault();
            }
            //else
            //{
            //    estadoEncontrado = _context.EstadosDeConservacion.Where(e => e.Nombre == NombreEstadoEnum.Deficiente).FirstOrDefault();
            //}

            return estadoEncontrado;
        }
    }
}
