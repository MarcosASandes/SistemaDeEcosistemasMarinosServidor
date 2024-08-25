using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class EditEspecieCU : IEditEspecieCU
    {
        private IRepositorioEspecie EspecieRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoConservacionRepositorio { get; set; }
        private IAddControlCambioCU CambiosCU;
        public EditEspecieCU(IRepositorioEspecie especieRepositorio, IAddControlCambioCU cambiosCU, IRepositorioEstadoConservacion estadoConservacionRepositorio)
        {
            EspecieRepositorio = especieRepositorio;
            CambiosCU = cambiosCU;
            EstadoConservacionRepositorio = estadoConservacionRepositorio;
        }

        public void editarEspecie(EspecieDTO espEditada, string alias)
        {
            Especie esp = EspecieRepositorio.FindById(espEditada.id);
            esp.Nombre = espEditada.nombre;
            esp.NombreCientifico = espEditada.nombreCientifico;
            esp.Descripcion = espEditada.descripcion;
            EspecieRepositorio.Update(esp);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, espEditada.id, "Especie");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
