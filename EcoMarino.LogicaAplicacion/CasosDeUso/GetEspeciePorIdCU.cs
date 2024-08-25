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
    public class GetEspeciePorIdCU : IGetEspeciePorIdCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetEspeciePorIdCU(IRepositorioEspecie especieRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
        }

        public EspecieDTO obtenerEspeciePorId(int idEsp)
        {
            EspecieDTO ret = new EspecieDTO();
            Especie EspecieEntidad = EspecieRepositorio.FindById(idEsp);
            ret.id = EspecieEntidad.Id;
            ret.descripcion = EspecieEntidad.Descripcion;
            ret.nombreCientifico = EspecieEntidad.NombreCientifico;
            ret.nombre = EspecieEntidad.Nombre;
            ret.nivelConservacion = EspecieEntidad.NivelConservacion;
            EstadoDTO est = new EstadoDTO(EspecieEntidad.Estado);
            ret.estado = est;
            ret.peso = EspecieEntidad.PesoLong.Peso;
            ret.longitud = EspecieEntidad.PesoLong.Longitud;
            ret.idEstado = EspecieEntidad.IdEstado;
            

            return ret;
        }
    }
}
