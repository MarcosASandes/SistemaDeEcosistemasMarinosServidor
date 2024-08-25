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
    public class AsociarEspecieCU : IAsociarEspecieCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion estadoRepo { get; set; }
        private IRepositorioPais PaisRepo { get; set; }
        private IRepositorioEspecie especieRepo { get; set; }
        private IRepositorioConfiguracion configuracion { get; set; }
        private IAddControlCambioCU CambiosCU;
        public AsociarEspecieCU(IRepositorioEcosistema ecosistemaRepositorio, IAddControlCambioCU cambiosCU, IRepositorioEstadoConservacion estadoRepo, IRepositorioPais paisRepo, IRepositorioConfiguracion configuracion,
            IRepositorioEspecie repoEsp)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            CambiosCU = cambiosCU;
            this.estadoRepo = estadoRepo;
            PaisRepo = paisRepo;
            especieRepo = repoEsp;
            this.configuracion = configuracion;
        }

        public void asociarUnaEspecie(EcosistemaDTO unEcoConEspecie, string alias)
        {
            Ecosistema eco = EcosistemaRepositorio.FindById(unEcoConEspecie.id);
            List<EcosistemaEspecieDTO> espdeeco = unEcoConEspecie._especies;
            foreach (EcosistemaEspecieDTO e in espdeeco)
            {
                Especie esp = especieRepo.FindById(e.idEspecie);
                eco.AgregarEspecie(esp, configuracion);
            }

            EcosistemaRepositorio.Update(eco);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, unEcoConEspecie.id, "Ecosistema");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
