using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        public Pais FindByCod(string id);
    }
}
