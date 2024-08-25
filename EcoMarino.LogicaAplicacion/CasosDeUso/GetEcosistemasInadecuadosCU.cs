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
    public class GetEcosistemasInadecuadosCU : IGetEcosistemasInadecuadosCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEspecie EspecieRepositorio { get; set; }

        public GetEcosistemasInadecuadosCU(IRepositorioEcosistema ecosistemaRepositorio,
            IRepositorioEspecie reposEsp)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            EspecieRepositorio = reposEsp;
        }

        public List<EcosistemaDTO> ObtenerEcosInhabitables(EspecieDTO esp)
        {
            Especie especieEntidad = EspecieRepositorio.FindById(esp.id);
            List<EcosistemaDTO> aRetorno = new List<EcosistemaDTO>();
            foreach (Ecosistema e in EcosistemaRepositorio.GetEcosistemasInadecuados(especieEntidad))
            {
                aRetorno.Add(new EcosistemaDTO(e));
            }

            return aRetorno;
        }
    }
}
