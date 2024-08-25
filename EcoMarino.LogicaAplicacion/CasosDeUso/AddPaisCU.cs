using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class AddPaisCU : IAddPaisCU
    {
        private IRepositorioPais PaisRepositorio { get; set; }

        public AddPaisCU(IRepositorioPais paisRepositorio)
        {
            PaisRepositorio = paisRepositorio;
        }

        public PaisDTO addPais(PaisDTO p)
        {
            Pais nuevoPais = new Pais();
            nuevoPais.CodigoAlpha = p.codigoAlpha;
            nuevoPais.Nombre= p.nombre;

            PaisRepositorio.Add(nuevoPais);
            return p;
        }
    }
}
