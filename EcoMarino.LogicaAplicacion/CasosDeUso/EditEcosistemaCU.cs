using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class EditEcosistemaCU : IEditEcosistemaCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoConservacionRepositorio { get; set; }
        private IRepositorioPais PaisRepositorio { get; set; }
        private IAddControlCambioCU CambiosCU;
        public EditEcosistemaCU(IRepositorioEcosistema ecosistemaRepositorio, IAddControlCambioCU cambiosCU, IRepositorioEstadoConservacion estadoConservacionRepositorio, IRepositorioPais paisRepositorio)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            CambiosCU = cambiosCU;
            EstadoConservacionRepositorio = estadoConservacionRepositorio;
            PaisRepositorio = paisRepositorio;
        }

        public void editarEcosistema(EcosistemaDTO ecoEditado, string alias)
        {
            Ecosistema eco = EcosistemaRepositorio.FindById(ecoEditado.id);
            eco.Descripcion = ecoEditado.descripcion;
            eco.Nombre = ecoEditado.nombre;
            EcosistemaRepositorio.Update(eco);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, ecoEditado.id, "Ecosistema");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
