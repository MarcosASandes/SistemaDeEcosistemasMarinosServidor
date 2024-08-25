using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EcosistemaAmenazaDTO
    {
        public int ecosistemaId { get; set; }
        public EcosistemaDTO? ecosistema { get; set; }
        public int amenazaId { get; set; }
        public AmenazaDTO? amenaza { get; set; }

        public EcosistemaAmenazaDTO() { }

        public EcosistemaAmenazaDTO(EcosistemaAmenaza ecoAmenaza)
        {
            this.ecosistemaId = ecoAmenaza.EcosistemaId;
            this.amenazaId = ecoAmenaza.AmenazaId;
        }

        public EcosistemaAmenazaDTO(int ecosistemaId, EcosistemaDTO? ecosistema, int amenazaId, AmenazaDTO? amenaza)
        {
            this.ecosistemaId = ecosistemaId;
            this.ecosistema = ecosistema;
            this.amenazaId = amenazaId;
            this.amenaza = amenaza;
        }
    }
}
