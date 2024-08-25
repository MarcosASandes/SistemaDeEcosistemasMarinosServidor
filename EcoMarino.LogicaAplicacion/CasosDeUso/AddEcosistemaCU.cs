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
    public class AddEcosistemaCU : IAddEcosistemaCU
    {
        private IRepositorioEcosistema EcosistemaRepo { get; set; }
        private IRepositorioPais PaisRepo { get; set; }
        private IRepositorioEstadoConservacion EstadoRepo { get; set; }
        public AddEcosistemaCU(IRepositorioEcosistema repoEco, IRepositorioPais paisRepo, IRepositorioEstadoConservacion estadoRepo)
        {
            this.EcosistemaRepo = repoEco;
            PaisRepo = paisRepo;
            EstadoRepo = estadoRepo;
        }

        public EcosistemaDTO AltaEcosistema(EcosistemaDTO unEco)
        {
            Ecosistema eco = new Ecosistema();
            UbicacionGeograficaVO ubi = new UbicacionGeograficaVO();
            ubi.Longitud = unEco.longitud;
            ubi.Latitud = unEco.latitud;
            eco.Ubicacion = ubi;
            eco.IdEstado = unEco.idEstado;
            eco.NivelConservacion = unEco.nivelConservacion;
            eco.Nombre = unEco.nombre;
            eco.CodigoAlpha = unEco.codigoAlpha;
            eco.Descripcion = unEco.descripcion;
            EcosistemaRepo.Add(eco);
            EcosistemaDTO retorno = new EcosistemaDTO(eco, eco.IdEstado);
            unEco.id = eco.Id;
            return retorno;
        }
    }
}
