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
    public class GetEspeciePorNomCU : IGetEspeciePorNomCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetEspeciePorNomCU(IRepositorioEspecie especieRepo)
        {
            this.EspecieRepositorio = especieRepo;
        }

        public List<EspecieDTO> getEspeciesPorNombre(string nombre)
        {
            List<EspecieDTO> ret = new List<EspecieDTO>();
            foreach(Especie e in EspecieRepositorio.GetEspeciePorNombre(nombre))
            {
                ret.Add(new EspecieDTO(e));
            }

            return ret;
        }
    }
}
