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
    public class GetConfiguracionPorNombreCU : IGetConfiguracionPorNombreCU
    {
        private IRepositorioConfiguracion ConfigRepo;

        public GetConfiguracionPorNombreCU(IRepositorioConfiguracion configRepo)
        {
            ConfigRepo = configRepo;
        }

        public ConfiguracionDTO obtenerConfigPorNombre(string nombreAtributo)
        {
            ConfiguracionDTO ret = new ConfiguracionDTO();
            Configuracion c = ConfigRepo.FindByNombreAtributo(nombreAtributo);
            ret.nombreAtributo = c.NombreAtributo;
            ret.topeInferior = c.TopeInferior;
            ret.topeSuperior = c.TopeSuperior;

            return ret;
        }
    }
}
