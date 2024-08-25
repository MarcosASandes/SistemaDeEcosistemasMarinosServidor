using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    /*Clase de asociación*/
    [PrimaryKey(nameof(Id), nameof(IdEcosistema))]
    public class EcosistemaImagen
    {
        #region Atributos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEcosistema { get; set; }
        public Ecosistema Eco { get; set; }
        public string ruta { get; set; }
        #endregion

        #region Constructores
        public EcosistemaImagen()
        {
            
        }

        public EcosistemaImagen(int idEcosistema, string ruta)
        {
            IdEcosistema = idEcosistema;
            Eco = null;
            this.ruta = ruta;
        }
        #endregion
    }
}
