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
    public class GetEstadoConservacionPorNivelCU : IGetEstadoConservacionPorNivelCU
    {
        private IRepositorioEstadoConservacion EstadoRepositorio { get; set; }
        public GetEstadoConservacionPorNivelCU(IRepositorioEstadoConservacion repoEstado)
        {
            this.EstadoRepositorio = repoEstado;
        }

        public EstadoDTO obtenerEstado(int nivel)
        {
            EstadoDTO ret = new EstadoDTO(EstadoRepositorio.FindByNivelConservacion(nivel));


            return ret;
        }
    }
}
