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
    public class GetAmenazaPorIdCU : IGetAmenazaPorIdCU
    {
        private IRepositorioAmenaza AmenazaRepositorio { get; set; }
        public GetAmenazaPorIdCU(IRepositorioAmenaza amenazaRepositorio)
        {
            AmenazaRepositorio = amenazaRepositorio;
        }

        public AmenazaDTO obtenerAmenazaPorId(int id)
        {
            AmenazaDTO ret = new AmenazaDTO();
            Amenaza am = AmenazaRepositorio.FindById(id);
            ret.descripcion = am.Descripcion;
            ret.id = am.Id;
            ret.gradoPeligro = am.GradoPeligro;

            return ret;
        }
    }
}
