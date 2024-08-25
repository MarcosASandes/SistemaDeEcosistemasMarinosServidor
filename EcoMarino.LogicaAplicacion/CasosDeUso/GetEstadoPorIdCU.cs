using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class GetEstadoPorIdCU : IGetEstadoPorIdCU
    {
        private IRepositorioEstadoConservacion EstadoConservacionRepositorio { get; set; }
        public GetEstadoPorIdCU(IRepositorioEstadoConservacion estadorepo)
        {
            this.EstadoConservacionRepositorio = estadorepo;
        }

        public EstadoDTO obtenerEstadoPorId(int id)
        {
            EstadoDTO retorno = new EstadoDTO();
            EstadoConservacion estadoEntidad = EstadoConservacionRepositorio.FindById(id);
            retorno.id = estadoEntidad.Id;
            retorno.nombre = estadoEntidad.Nombre;

            return retorno;
        }
    }
}
