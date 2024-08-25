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
    public class GetEspeciesPorPesoCU : IGetEspeciesPorPesoCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetEspeciesPorPesoCU(IRepositorioEspecie especieRepo)
        {
            this.EspecieRepositorio = especieRepo;
        }

        public List<EspecieDTO> getEspeciesPorRangoPeso(double minimo, double maximo)
        {
            List<EspecieDTO> ret = new List<EspecieDTO>();
            foreach(Especie e in EspecieRepositorio.GetEspeciesPorRangoPeso(minimo, maximo))
            {
                ret.Add(new EspecieDTO(e));
            }


            return ret;
        }
    }
}
