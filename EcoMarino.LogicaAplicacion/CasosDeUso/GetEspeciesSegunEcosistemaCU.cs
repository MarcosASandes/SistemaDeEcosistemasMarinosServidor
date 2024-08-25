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
    public class GetEspeciesSegunEcosistemaCU : IGetEspeciesSegunEcosistemaCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoRepositorio { get; set; }
        public GetEspeciesSegunEcosistemaCU(IRepositorioEcosistema ecosistemaRepositorio, IRepositorioEstadoConservacion estadoRepositorio)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            EstadoRepositorio = estadoRepositorio;
        }

        public List<EspecieDTO> obtenerEspeciesDeEcosistema(int idEco)
        {
            List<EspecieDTO> retorno = new List<EspecieDTO>();
            foreach (Especie e in EcosistemaRepositorio.GetEspeciesDeEcosistema(idEco))
            {
                EspecieDTO especie = new EspecieDTO(e, e.IdEstado);
                EstadoDTO est = new EstadoDTO(EstadoRepositorio.FindById(e.IdEstado));
                especie.estado = est;
                retorno.Add(especie);
            }
            return retorno;
        }
    }
}
