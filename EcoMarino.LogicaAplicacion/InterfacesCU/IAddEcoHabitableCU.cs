using EcoMarino.Entidades;
using EcoMarino.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.InterfacesCU
{
	public interface IAddEcoHabitableCU
	{
		public void agregarEcosistemaHabitable(EspecieDTO unaEsp, string alias);
	}
}
