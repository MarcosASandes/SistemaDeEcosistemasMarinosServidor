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
    public class AddEspecieCU : IAddEspecieCU
    {
        private IRepositorioEspecie EspecieRepo { get; set; }
        private IRepositorioEstadoConservacion EstadoRepo { get; set; }
        public AddEspecieCU(IRepositorioEspecie repoEspecie, IRepositorioEstadoConservacion estadoRepo)
        {
            this.EspecieRepo = repoEspecie;
            EstadoRepo = estadoRepo;
        }

        public EspecieDTO AltaEspecie(EspecieDTO especie)
        {
            Especie esp = new Especie();
            PesoLongEspecieVO pl = new PesoLongEspecieVO();
            pl.Longitud = especie.longitud;
            pl.Peso = especie.peso;
            esp.PesoLong = pl;
            esp.NivelConservacion = especie.nivelConservacion;
            esp.Nombre = especie.nombre;
            esp.NombreCientifico = especie.nombreCientifico;
            esp.IdEstado = especie.idEstado;
            esp.Descripcion = especie.descripcion;


            EspecieRepo.Add(esp);
            EspecieDTO retorno = new EspecieDTO(esp, esp.IdEstado);

            especie.id = esp.Id;
            return retorno;
        }
    }
}
