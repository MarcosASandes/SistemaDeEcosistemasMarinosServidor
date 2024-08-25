using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EspecieImagenDTO
    {
        public int id { get; set; }
        public int idEspecie { get; set; }
        public EspecieDTO? esp { get; set; }
        public string ruta { get; set; }

        public EspecieImagenDTO() { }

        public EspecieImagenDTO(EspecieImagen espImg)
        {
            this.id = espImg.Id;
            this.idEspecie = espImg.IdEspecie;
            this.ruta = espImg.ruta;
        }

        public EspecieImagenDTO(int id, int idEspecie, EspecieDTO? esp, string ruta)
        {
            this.id = id;
            this.idEspecie = idEspecie;
            this.esp = esp;
            this.ruta = ruta;
        }
    }
}
