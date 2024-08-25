using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class AsociarAmenazaEcosistemaCU : IAsociarAmenazaEcosistemaCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioPais PaisRepo { get; set; } 
        private IRepositorioEstadoConservacion EstadoRepositorio { get; set; }
        private IRepositorioConfiguracion configuracion { get; set; }
        private IRepositorioAmenaza AmenazaRepo { get; set; }
        private IAddControlCambioCU CambiosCU;
        public AsociarAmenazaEcosistemaCU(IRepositorioEcosistema ecosistemaRepositorio, IAddControlCambioCU cambiosCU, IRepositorioPais paisRepo, IRepositorioAmenaza amenazaRepo, IRepositorioConfiguracion configuracion)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            CambiosCU = cambiosCU;
            PaisRepo = paisRepo;
            AmenazaRepo = amenazaRepo;
            this.configuracion = configuracion;
        }

        public void asociarAmenaza(EcosistemaDTO ecoConAmenaza, string a)
        {
            Ecosistema eco = EcosistemaRepositorio.FindById(ecoConAmenaza.id);
            List<EcosistemaAmenazaDTO> amenazasDeEco = ecoConAmenaza._amenazas;
            foreach(EcosistemaAmenazaDTO e in amenazasDeEco)
            {
                Amenaza eAm = AmenazaRepo.FindById(e.amenazaId);
                eco.AgregarAmenaza(eAm, configuracion);
            }

            EcosistemaRepositorio.Update(eco);
            ControlCambios nuevoCambio = new ControlCambios(a, DateTime.Now, ecoConAmenaza.id, "Ecosistema");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
