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
    public class GetAmenazasSegunEcosistemaCU : IGetAmenazasSegunEcosistemaCU
    {
        private IRepositorioAmenaza AmenazaRepositorio { get; set; }
        public GetAmenazasSegunEcosistemaCU(IRepositorioAmenaza amenazaRepositorio)
        {
            AmenazaRepositorio = amenazaRepositorio;
        }

        public List<AmenazaDTO> obtenerAmenazasDeEcosistema(int idEco)
        {
            List<AmenazaDTO> ret = new List<AmenazaDTO>();
            foreach(Amenaza a in AmenazaRepositorio.GetAmenazasPorEcosistemaId(idEco))
            {
                ret.Add(new AmenazaDTO(a));
            }

            return ret;
        }
    }
}
