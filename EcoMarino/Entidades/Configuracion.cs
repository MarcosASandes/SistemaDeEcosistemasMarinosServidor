using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    public class Configuracion
    {
        [Key]
        [Display(Name = "Elemento")]
        public string NombreAtributo { get; set; }
        [Display(Name = "Tope mínimo")]
        public int TopeInferior { get; set; }
        [Display(Name = "Tope máximo")]
        public int TopeSuperior { get; set; }
        public Configuracion() { }
    }
}
