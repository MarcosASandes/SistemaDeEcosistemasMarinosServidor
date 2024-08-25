using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class GetPrimerImagenEcoCU : IGetPrimerImagenEcoCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        public GetPrimerImagenEcoCU(IRepositorioEcosistema ecosistemaRepositorio)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
        }

        public string obtenerPrimerImagenDeEco(int idEco)
        {
            return EcosistemaRepositorio.GetPrimerImagen(idEco);
        }
    }
}
