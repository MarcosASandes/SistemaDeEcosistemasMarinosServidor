using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioEstadoConservacion : IRepositorio<EstadoConservacion>
    {
        public EstadoConservacion FindByNivelConservacion(int nivel);
    }
}
