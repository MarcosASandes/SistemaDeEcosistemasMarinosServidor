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
    public class GetAllAmenazasCU : IGetAllAmenazasCU
    {
        private IRepositorioAmenaza AmenazaRepositorio { get; set; }
        public GetAllAmenazasCU(IRepositorioAmenaza amenazaRepositorio)
        {
            AmenazaRepositorio = amenazaRepositorio;
        }

        public List<AmenazaDTO> obtenerAmenazas()
        {
            List<AmenazaDTO> ret = new List<AmenazaDTO>();
            foreach(Amenaza a in AmenazaRepositorio.FindAll())
            {
                ret.Add(new AmenazaDTO(a));
            }
            return ret;
        }
    }
}
