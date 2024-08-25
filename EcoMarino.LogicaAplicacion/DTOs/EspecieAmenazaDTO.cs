using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EspecieAmenazaDTO
    {
        public int idEspecie { get; set; }
        public EspecieDTO? especie { get; set; }
        public int idAmenaza { get; set; }
        public AmenazaDTO? amenaza { get; set; }

        public EspecieAmenazaDTO() { }

        public EspecieAmenazaDTO(EspecieAmenaza espAm)
        {
            this.idEspecie = espAm.idEspecie;
            this.idAmenaza = espAm.idAmenaza;
        }

        public EspecieAmenazaDTO(int idEspecie, EspecieDTO? especie, int idAmenaza, AmenazaDTO? amenaza)
        {
            this.idEspecie = idEspecie;
            this.especie = especie;
            this.idAmenaza = idAmenaza;
            this.amenaza = amenaza;
        }
    }
}
