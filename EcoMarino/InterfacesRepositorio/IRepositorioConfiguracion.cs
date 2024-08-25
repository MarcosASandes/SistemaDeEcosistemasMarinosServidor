using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
    {
        public int GetTopeInferior(string nombreAtributo);
        public int GetTopeSuperior(string nombreAtributo);

        public Configuracion FindByNombreAtributo(string nombreAtributo);

    }
}
