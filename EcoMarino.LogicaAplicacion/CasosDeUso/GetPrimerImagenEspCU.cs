using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class GetPrimerImagenEspCU : IGetPrimerImagenEspCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        public GetPrimerImagenEspCU(IRepositorioEspecie especieRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
        }

        public string obtenerPrimerImagenEsp(int idEsp)
        {
            return EspecieRepositorio.GetPrimerImagen(idEsp);
        }
    }
}
