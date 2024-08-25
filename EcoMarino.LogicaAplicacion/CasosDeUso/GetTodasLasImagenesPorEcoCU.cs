using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class GetTodasLasImagenesPorEcoCU : IGetTodasLasImagenesPorEcoCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        public GetTodasLasImagenesPorEcoCU(IRepositorioEcosistema ecosistemaRepositorio)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
        }

        public List<string> obtenerTodasLasRutasPorEco(int idEco)
        {
            return EcosistemaRepositorio.GetImagenesDeEcosistema(idEco);
        }
    }
}
