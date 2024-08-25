using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesEntidades
{
    public interface IValidable
    {
        public void Validar(IRepositorioConfiguracion config);
    }
}
