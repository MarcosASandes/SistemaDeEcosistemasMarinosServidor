using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    /*Clase de asociación*/
    [PrimaryKey(nameof(Id), nameof(IdEspecie))]
    public class EspecieImagen
    {
        #region Atributos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEspecie { get; set; }
        public Especie Esp { get; set; }
        public string ruta { get; set; }
        #endregion

        #region Constructores
        public EspecieImagen()
        {

        }

        public EspecieImagen(int idEsp, string ruta)
        {
            IdEspecie = idEsp;
            Esp = null;
            this.ruta = ruta;
        }
        #endregion
    }
}
