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
    public class GetTodasLasEspeciesCU : IGetTodasLasEspeciesCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetTodasLasEspeciesCU(IRepositorioEspecie especieRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
        }

        public List<EspecieDTO> obtenerTodasLasEspecies()
        {
            List<EspecieDTO> retorno = new List<EspecieDTO>();
            foreach(Especie e in EspecieRepositorio.FindAll())
            {
                retorno.Add(new EspecieDTO(e));
            }


            return retorno;
        }
    }
}
