using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class AmenazaDTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int gradoPeligro { get; set; }

        public AmenazaDTO() { }

        public AmenazaDTO(Amenaza a)
        {
            this.id = a.Id;
            this.descripcion = a.Descripcion;
            this.gradoPeligro = a.GradoPeligro;
        }

        public AmenazaDTO(int id, string descripcion, int gradoPeligro)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.gradoPeligro = gradoPeligro;
        }
    }
}
