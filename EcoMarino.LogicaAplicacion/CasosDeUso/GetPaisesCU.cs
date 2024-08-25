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
    public class GetPaisesCU : IGetPaisesCU
    {
        private IRepositorioPais PaisRepo;
        public GetPaisesCU(IRepositorioPais repoPais)
        {
            this.PaisRepo = repoPais;
        }

        public List<PaisDTO> ObtenerPaises()
        {
            List<PaisDTO> retorno = new List<PaisDTO>();
            foreach(Pais p in PaisRepo.FindAll())
            {
                retorno.Add(new PaisDTO(p));
            }

            return retorno;
        }
    }
}
