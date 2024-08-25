using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class PaisDTO
    {
        public string nombre { get; set; }
        public string codigoAlpha { get; set; }

        public PaisDTO() { }
        public PaisDTO(Pais p)
        {
            this.nombre = p.Nombre;
            this.codigoAlpha = p.CodigoAlpha;
        }

        public PaisDTO(string nombre, string codigoAlpha)
        {
            this.nombre = nombre;
            this.codigoAlpha = codigoAlpha;
        }
    }
}
