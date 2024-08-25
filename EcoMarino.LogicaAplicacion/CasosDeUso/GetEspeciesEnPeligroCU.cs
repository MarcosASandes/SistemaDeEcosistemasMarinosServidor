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
    public class GetEspeciesEnPeligroCU : IGetEspeciesEnPeligroCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetEspeciesEnPeligroCU(IRepositorioEspecie especieRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
        }

        public List<EspecieDTO> ObtenerEspeciesEnPeligro()
        {
            List<EspecieDTO> ret = new List<EspecieDTO>();
            foreach(Especie e in EspecieRepositorio.GetEspeciesEnPeligroDeExtincion())
            {
                ret.Add(new EspecieDTO(e));
            }

            return ret;
        }
    }
}
