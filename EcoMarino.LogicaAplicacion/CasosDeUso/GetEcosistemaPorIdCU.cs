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
    public class GetEcosistemaPorIdCU : IGetEcosistemaPorIdCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        public GetEcosistemaPorIdCU(IRepositorioEcosistema ecosistemaRepositorio)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
        }

        public EcosistemaDTO GetEcoPorId(int id)
        {
            EcosistemaDTO ret = new EcosistemaDTO();
            Ecosistema eco = EcosistemaRepositorio.FindById(id);
            ret.id = eco.Id;
            ret.descripcion = eco.Descripcion;
            ret.nivelConservacion = eco.NivelConservacion;
            EstadoDTO est = new EstadoDTO(eco.Estado);
            ret.estado = est;
            ret.idEstado = eco.IdEstado;
            ret.latitud = eco.Ubicacion.Latitud;
            ret.longitud = eco.Ubicacion.Longitud;
            PaisDTO p = new PaisDTO(eco.PaisResponsable);
            ret.paisResponsable = p;
            ret.nombre = eco.Nombre;


            return ret;
        }
    }
}
