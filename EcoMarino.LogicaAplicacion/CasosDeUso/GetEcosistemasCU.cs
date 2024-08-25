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
    public class GetEcosistemasCU : IGetEcosistemasCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        public GetEcosistemasCU(IRepositorioEcosistema repoEcosistema)
        {
            this.EcosistemaRepositorio = repoEcosistema;
        }

        public List<EcosistemaDTO> GetEcosistemas()
        {
            List<EcosistemaDTO> aRetorno = new List<EcosistemaDTO>();
            foreach(Ecosistema e in EcosistemaRepositorio.FindAll())
            {
                aRetorno.Add(new EcosistemaDTO(e));
            }

            return aRetorno;
        }
    }
}
