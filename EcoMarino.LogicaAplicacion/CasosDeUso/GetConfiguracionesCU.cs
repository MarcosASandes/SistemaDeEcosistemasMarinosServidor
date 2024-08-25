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
    public class GetConfiguracionesCU : IGetConfiguracionesCU
    {
        private IRepositorioConfiguracion repoConfiguracion;

        public GetConfiguracionesCU(IRepositorioConfiguracion repoConfiguracion)
        {
            this.repoConfiguracion = repoConfiguracion;
        }

        public List<ConfiguracionDTO> ObtenerConfiguraciones()
        {
            List<ConfiguracionDTO> ret = new List<ConfiguracionDTO>();
            foreach(Configuracion c in repoConfiguracion.FindAll())
            {
                ret.Add(new ConfiguracionDTO(c));
            }

            return ret;
        }
    }
}
