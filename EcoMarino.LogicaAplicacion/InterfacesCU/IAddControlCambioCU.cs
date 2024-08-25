using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.InterfacesCU
{
    public interface IAddControlCambioCU
    {
        public void RegistrarCambio(ControlCambios nuevoCambio);
    }
}
