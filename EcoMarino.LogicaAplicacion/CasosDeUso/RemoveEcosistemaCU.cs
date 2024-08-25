using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class RemoveEcosistemaCU : IRemoveEcosistemaCU
    {
        private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoConservacionRepositorio { get; set; }
        private IRepositorioPais PaisRepositorio { get; set; }
        private IAddControlCambioCU CambiosCU;
        public RemoveEcosistemaCU(IRepositorioEcosistema ecosistemaRepositorio, IAddControlCambioCU cambiosCU,
            IRepositorioEstadoConservacion repoEstado, IRepositorioPais repoPais)
        {
            EcosistemaRepositorio = ecosistemaRepositorio;
            EstadoConservacionRepositorio = repoEstado;
            PaisRepositorio = repoPais;
            CambiosCU = cambiosCU;
        }

        public void RemoveEcosistema(EcosistemaDTO obj, string alias)
        {
            Ecosistema eco = EcosistemaRepositorio.FindById(obj.id);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, obj.id, "Ecosistema");
            EcosistemaRepositorio.Delete(eco);
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
    }
}
