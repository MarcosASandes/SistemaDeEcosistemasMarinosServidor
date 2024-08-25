using EcoMarino.Entidades;
using EcoMarino.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EstadoDTO
    {
        public int id { get; set; }
        public NombreEstadoEnum nombre { get; set; }

        public EstadoDTO() { }

        public EstadoDTO(EstadoConservacion e)
        {
            this.id = e.Id;
            this.nombre = e.Nombre;
        }

        public EstadoDTO(int id, NombreEstadoEnum nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
