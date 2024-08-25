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
    public class EditConfiguracionCU : IEditConfiguracionCU
    {
        
        private IRepositorioConfiguracion repoConfig { get; set; }
        public EditConfiguracionCU(IRepositorioConfiguracion repoConfig)
        {
            this.repoConfig = repoConfig;
        }

        public void editarConfiguracion(ConfiguracionDTO configEditada)
        {
            Configuracion conf = repoConfig.FindByNombreAtributo(configEditada.nombreAtributo);
            conf.TopeInferior = configEditada.topeInferior;
            conf.TopeSuperior = configEditada.topeSuperior;
            repoConfig.Update(conf);
        }
    }
}
