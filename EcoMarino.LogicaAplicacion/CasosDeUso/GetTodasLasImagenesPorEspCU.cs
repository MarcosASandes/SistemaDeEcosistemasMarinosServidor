using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class GetTodasLasImagenesPorEspCU : IGetTodasLasImagenesPorEspCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetTodasLasImagenesPorEspCU(IRepositorioEspecie especieRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
        }

        public List<string> obtenerTodasLasRutasEspecie(int idEsp)
        {
            return EspecieRepositorio.GetImagenesDeEspecie(idEsp);
        }
    }
}
