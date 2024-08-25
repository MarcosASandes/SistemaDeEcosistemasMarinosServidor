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

    public class CambiarNombreImagenEspecieCU : ICambiarNombreImagenEspecieCU
    {
        private readonly IRepositorioEspecie especieRepo;
        private IRepositorioEstadoConservacion estadoRepo { get; set; }
        private IAddControlCambioCU CambiosCU;

        public CambiarNombreImagenEspecieCU(IRepositorioEspecie repositorioEspecie, IAddControlCambioCU cambiosCU, IRepositorioEstadoConservacion estadoRepo)
        {
            this.especieRepo = repositorioEspecie;
            CambiosCU = cambiosCU;
            this.estadoRepo = estadoRepo;
        }

        public void CambiarNombreImagenEspecie(EspecieDTO e, string alias)
        {
            Especie esp = especieRepo.FindById(e.id);
            List<EspecieImagenDTO> imgDto = e._imagenes;
            foreach (EspecieImagenDTO ecoimg in imgDto)
            {
                esp.AgregarImagen(ecoimg.ruta);
            }

            especieRepo.Update(esp);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, e.id, "Especie");
            CambiosCU.RegistrarCambio(nuevoCambio);

        }
    }
}
