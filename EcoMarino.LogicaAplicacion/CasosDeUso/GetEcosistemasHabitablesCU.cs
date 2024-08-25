using EcoMarino.AccesoDatos.InMemory;
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
    public class GetEcosistemasHabitablesCU : IGetEcosistemasHabitablesCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoRepo { get; set; }
        private IRepositorioPais repositorioPais { get; set; }
        public GetEcosistemasHabitablesCU(IRepositorioEspecie especieRepositorio,
            IRepositorioEcosistema repoEco,
            IRepositorioEstadoConservacion estadoRepo,
            IRepositorioPais repositorioPais)
        {
            EspecieRepositorio = especieRepositorio;
            EcosistemaRepositorio = repoEco;
            EstadoRepo = estadoRepo;
            this.repositorioPais = repositorioPais;
        }

        public List<EcosistemaDTO> getEcosHabitables(int idEsp)
        {
            List<EcosistemaDTO> ret = new List<EcosistemaDTO>();
            foreach(Ecosistema e in EspecieRepositorio.GetEcosistemasHabitables(idEsp))
            {
                EcosistemaDTO eco = new EcosistemaDTO(e, e.IdEstado);
                EstadoDTO est = new EstadoDTO(EstadoRepo.FindById(e.IdEstado));
                PaisDTO p = new PaisDTO(repositorioPais.FindByCod(e.CodigoAlpha));
                eco.paisResponsable = p;
                eco.estado = est;
                ret.Add(eco);
            }

            return ret;
        }
    }
}
