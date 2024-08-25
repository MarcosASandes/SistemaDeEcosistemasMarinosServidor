using EcoMarino.AccesoDatos.EntityFramework.SQL;
using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class AddControlCambioCU : IAddControlCambioCU
    {
        private IRepositorioCambios CambiosRepositorio { get; set; }
        public AddControlCambioCU(IRepositorioCambios cambiosRepositorio)
        {
            CambiosRepositorio = cambiosRepositorio;
        }

        public void RegistrarCambio(ControlCambios nuevoCambio)
        {
            CambiosRepositorio.Add(nuevoCambio);
        }
    }
}
