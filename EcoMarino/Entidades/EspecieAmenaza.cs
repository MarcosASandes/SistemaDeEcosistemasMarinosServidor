using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    /*Clase de asociación*/
    public class EspecieAmenaza
    {
        #region Atributos
        public int idEspecie { get; set; }
        public Especie Especie { get; set; }
        public int idAmenaza { get; set; }
        public Amenaza Amenaza { get; set; }
        #endregion

        #region Constructores
        public EspecieAmenaza() { }

        public EspecieAmenaza(int idEspecie, int idAmenaza, Amenaza amenaza)
        {
            this.idAmenaza = idAmenaza;
            Amenaza = amenaza;
            this.idEspecie = idEspecie;
        }
        public EspecieAmenaza(int idEspecie)
        {
            this.idEspecie = idEspecie;
        }
        #endregion
    }
}
