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
    public class GetTodosLosCambiosCU : IGetTodosLosCambiosCU
    {
        private IRepositorioCambios CambiosRepositorio { get; set; }
        public GetTodosLosCambiosCU(IRepositorioCambios cambiosRepositorio)
        {
            CambiosRepositorio = cambiosRepositorio;
        }

        public List<CambiosDTO> getAllCambios()
        {
            List<CambiosDTO> retorno = new List<CambiosDTO>();
            foreach(ControlCambios c in CambiosRepositorio.FindAll())
            {
                retorno.Add(new CambiosDTO(c));
            }

            return retorno;
        }
    }
}
