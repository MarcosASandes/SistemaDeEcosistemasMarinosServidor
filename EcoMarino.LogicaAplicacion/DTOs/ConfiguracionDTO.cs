using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class ConfiguracionDTO
    {
        public string nombreAtributo { get; set; }
        public int topeInferior { get; set; }
        public int topeSuperior { get; set; }

        public ConfiguracionDTO() { }

        public ConfiguracionDTO(Configuracion configuracion)
        {
            this.nombreAtributo = configuracion.NombreAtributo;
            this.topeInferior = configuracion.TopeInferior;
            this.topeSuperior = configuracion.TopeSuperior;
        }

        public ConfiguracionDTO(string nombreAtributo, int topeInferior, int topeSuperior)
        {
            this.nombreAtributo = nombreAtributo;
            this.topeInferior = topeInferior;
            this.topeSuperior = topeSuperior;
        }
    }
}
