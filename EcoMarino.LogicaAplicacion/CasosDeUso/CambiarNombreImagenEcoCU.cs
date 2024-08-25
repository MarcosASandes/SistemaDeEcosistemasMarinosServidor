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
    public class CambiarNombreImagenEcoCU : ICambiarNombreImagenEcoCU
    {
        private readonly IRepositorioEcosistema ecosistemaRepo;
        private IRepositorioEstadoConservacion estadoRepo { get; set; }
        private IRepositorioPais PaisRepo { get; set; }
        private IRepositorioConfiguracion configuracion { get; set; }
        private IAddControlCambioCU CambiosCU;

        public CambiarNombreImagenEcoCU(IRepositorioEcosistema ecosistemaRepo, IAddControlCambioCU cambiosRepositorio,
            IRepositorioEstadoConservacion estadorepo, IRepositorioPais repoPais,
            IRepositorioConfiguracion configrepo)
        {
            this.ecosistemaRepo = ecosistemaRepo;
            this.estadoRepo = estadoRepo;
            this.PaisRepo = repoPais;
            this.configuracion = configrepo;
            this.CambiosCU = cambiosRepositorio;
        }
    
        public void CambiarNombreImagenEco(EcosistemaDTO e, string alias)
        {
            Ecosistema eco = ecosistemaRepo.FindById(e.id);
            List<EcosistemaImagenDTO> espdeeco = e._imagenes;
            foreach (EcosistemaImagenDTO imgEco in espdeeco)
            {
                eco.AgregarImagen(imgEco.ruta);
            }

            ecosistemaRepo.Update(eco);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, e.id, "Ecosistema");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
