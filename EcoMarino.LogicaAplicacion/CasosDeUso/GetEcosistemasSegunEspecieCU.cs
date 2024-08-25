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
    public class GetEcosistemasSegunEspecieCU : IGetEcosistemasSegunEspecieCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoRepo { get; set; }
        private IRepositorioPais PaisRepo { get; set; }
        public GetEcosistemasSegunEspecieCU(IRepositorioEspecie especieRepositorio, IRepositorioEstadoConservacion estadoRepo, IRepositorioPais paisRepo)
        {
            EspecieRepositorio = especieRepositorio;
            EstadoRepo = estadoRepo;
            PaisRepo = paisRepo;
        }

        public List<EcosistemaDTO> getEcosSegunEspecie(int idEsp)
        {
            List<EcosistemaDTO> ret = new List<EcosistemaDTO>();
            foreach(Ecosistema e in EspecieRepositorio.GetEcosistemasDeEspecie(idEsp))
            {
                EcosistemaDTO eco = new EcosistemaDTO(e, e.IdEstado);
                EstadoDTO estado = new EstadoDTO(EstadoRepo.FindById(e.IdEstado));
                PaisDTO p = new PaisDTO(PaisRepo.FindByCod(e.CodigoAlpha));
                eco.estado = estado;
                eco.paisResponsable = p;
                ret.Add(eco);
            }

            return ret;
        }
    }
}
