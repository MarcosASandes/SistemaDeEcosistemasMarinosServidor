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
	public class AddEcoHabitableCU : IAddEcoHabitableCU
	{
		private IRepositorioEspecie EspecieRepositorio { get; set; }
		private IRepositorioEcosistema EcosistemaRepositorio { get; set; }
        private IRepositorioEstadoConservacion EstadoRepositorio { get; set; }
        private IAddControlCambioCU CambiosCU;
        private IRepositorioConfiguracion configRepo;
        public AddEcoHabitableCU(IRepositorioEspecie especieRepositorio, IAddControlCambioCU cambiosRepositorio,
            IRepositorioEstadoConservacion repoEstado,
			IRepositorioEcosistema ecoRepo,
            IRepositorioConfiguracion config)
		{
			EspecieRepositorio = especieRepositorio;
			EstadoRepositorio = repoEstado;
			EcosistemaRepositorio = ecoRepo;
			configRepo = config;
            this.CambiosCU = cambiosRepositorio;
        }

		public void agregarEcosistemaHabitable(EspecieDTO unaEsp, string alias)
		{
			Especie esp = EspecieRepositorio.FindById(unaEsp.id);
			foreach(EcosistemaEspecieDTO e in unaEsp._ecosistemas)
			{
				Ecosistema ecoParaAgregar = EcosistemaRepositorio.FindById(e.idEcosistema);
				esp.AgregarEcosistemaHabitable(ecoParaAgregar, configRepo);
			}
			


			EspecieRepositorio.Update(esp);
            ControlCambios nuevoCambio = new ControlCambios(alias, DateTime.Now, unaEsp.id, "Especie");
            CambiosCU.RegistrarCambio(nuevoCambio);
        }
	}
}
