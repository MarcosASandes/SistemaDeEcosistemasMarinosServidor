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
    public class GetEspeciesDeEcosistemasCU : IGetEspeciesDeEcosistemasCU
    {
        private IRepositorioEcosistema EcoRepo { get; set; }
        private IRepositorioEstadoConservacion EstadoRepo { get; set; }
        public GetEspeciesDeEcosistemasCU(IRepositorioEcosistema Repo, IRepositorioEstadoConservacion estadoRepo)
        {
            EcoRepo = Repo;
            EstadoRepo = estadoRepo;
        }

        public List<EspecieDTO> GetEspeciesDeEco(int idEco)
        {
            List<EspecieDTO> ret = new List<EspecieDTO>();
            foreach(Especie e in EcoRepo.GetEspeciesDeEcosistema(idEco))
            {
                EspecieDTO esp = new EspecieDTO(e, e.IdEstado);
                EstadoDTO est = new EstadoDTO(EstadoRepo.FindById(e.IdEstado));
                esp.estado = est;
                ret.Add(esp);
            }

            return ret;
        }
    }
}
