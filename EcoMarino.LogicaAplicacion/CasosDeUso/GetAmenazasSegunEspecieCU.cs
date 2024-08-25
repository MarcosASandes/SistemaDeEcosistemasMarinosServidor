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
    public class GetAmenazasSegunEspecieCU : IGetAmenazasSegunEspecieCU
    {
        private IRepositorioAmenaza AmenazaRepositorio { get; set; }
        public GetAmenazasSegunEspecieCU(IRepositorioAmenaza amenazaRepositorio)
        {
            AmenazaRepositorio = amenazaRepositorio;
        }

        public List<AmenazaDTO> obtenerAmenazasSegunIdEspecie(int idEsp)
        {
            List<AmenazaDTO> ret = new List<AmenazaDTO>();
            foreach(Amenaza a in AmenazaRepositorio.GetAmenazasPorEspecieId(idEsp))
            {
                ret.Add(new AmenazaDTO(a));
            }
            return ret;
        }
    }
}
