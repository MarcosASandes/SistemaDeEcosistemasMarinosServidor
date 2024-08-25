using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class AsociarAmenazaEspecieCU : IAsociarAmenazaEspecieCU
    {
        private IRepositorioEspecie especieRepositorio { get; set; }
        private IRepositorioEstadoConservacion estadoRepo { get; set; }
        private IRepositorioAmenaza AmenazaRepo { get; set; }
        private IRepositorioConfiguracion configuracion { get; set; }
        private IAddControlCambioCU CambiosCU;

        public AsociarAmenazaEspecieCU(IRepositorioEspecie repoEspecie, IAddControlCambioCU cambiosCU,
            IRepositorioEstadoConservacion repoEstado, IRepositorioConfiguracion configuracion, IRepositorioAmenaza amenazaRepo)
        {
            this.especieRepositorio = repoEspecie;
            this.estadoRepo = repoEstado;
            CambiosCU = cambiosCU;
            this.configuracion = configuracion;
            AmenazaRepo = amenazaRepo;
        }

        public void asociarAmenazaEspecie(EspecieDTO especie, string alias)
        {
            Especie esp = especieRepositorio.FindById(especie.id);
            List<EspecieAmenazaDTO> amenazasDeEsp = especie._amenazas;
            foreach (EspecieAmenazaDTO e in amenazasDeEsp)
            {
                Amenaza eAm = AmenazaRepo.FindById(e.idAmenaza);
                esp.AgregarAmenaza(eAm, configuracion);
            }

            especieRepositorio.Update(esp);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, especie.id, "Especie");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
