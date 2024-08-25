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
    public class GetPaisPorIdCU : IGetPaisPorIdCU
    {
        private IRepositorioPais paisRepo;
        public GetPaisPorIdCU(IRepositorioPais paisRepo)
        {
            this.paisRepo = paisRepo;
        }

        public PaisDTO ObtenerPaisPorId(string id)
        {
            PaisDTO retorno = new PaisDTO();
            Pais pEntidad = paisRepo.FindByCod(id);
            retorno.codigoAlpha = pEntidad.CodigoAlpha;
            retorno.nombre = pEntidad.Nombre;

            return retorno;
        }
    }
}
