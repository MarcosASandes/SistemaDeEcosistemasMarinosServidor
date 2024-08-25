using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    /*Clase de asociación*/
    public class EcosistemaAmenaza
    {
        #region Atributos
        public int EcosistemaId { get; set; }
        public Ecosistema Ecosistema { get; set; }

        public int AmenazaId { get; set; }
        public Amenaza Amenaza { get; set; }
        #endregion

        #region Constructores
        public EcosistemaAmenaza() { }
        public EcosistemaAmenaza(int ecosistemaId)
        {
            this.EcosistemaId = ecosistemaId;
        }

        public EcosistemaAmenaza(int ecosistemaId, int amenazaId, Amenaza unaAmenaza)
        {
            this.EcosistemaId = ecosistemaId;
            this.AmenazaId = amenazaId;
            this.Amenaza = unaAmenaza;
        }
        #endregion
    }
}
