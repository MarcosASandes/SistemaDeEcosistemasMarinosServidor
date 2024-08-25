using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class CambiosDTO
    {
        public int id { get; set; }
        public string nombreResponsable { get; set; }
        public DateTime fechaHora { get; set; }
        public int idEntidad { get; set; }
        public string tipoEntidad { get; set; }

        public CambiosDTO() { }

        public CambiosDTO(ControlCambios c)
        {
            this.id = c.Id;
            this.nombreResponsable = c.NombreResponsable;
            this.fechaHora = c.FechaHora;
            this.idEntidad = c.IdEntidad;
            this.tipoEntidad = c.TipoEntidad;
        }

        public CambiosDTO(int id, string nombreResponsable, DateTime fechaHora, int idEntidad, string tipoEntidad)
        {
            this.id = id;
            this.nombreResponsable = nombreResponsable;
            this.fechaHora = fechaHora;
            this.idEntidad = idEntidad;
            this.tipoEntidad = tipoEntidad;
        }
    }
}
