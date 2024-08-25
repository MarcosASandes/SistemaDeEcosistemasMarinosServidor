using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.InterfacesCU
{
    public interface IGetTodasLasImagenesPorEspCU
    {
        public List<string> obtenerTodasLasRutasEspecie(int idEsp);
    }
}
