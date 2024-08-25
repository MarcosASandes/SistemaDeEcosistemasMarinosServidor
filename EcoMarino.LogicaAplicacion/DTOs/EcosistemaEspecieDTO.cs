using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EcosistemaEspecieDTO
    {

        public int idEcosistema { get; set; }
        public EcosistemaDTO? ecosistema { get; set; }
        public int idEspecie { get; set; }
        public EspecieDTO? especie { get; set; }
        public bool loHabita { get; set; }

        public EcosistemaEspecieDTO() { }

        public EcosistemaEspecieDTO(EcosistemaEspecie ecoEsp)
        {
            this.idEcosistema = ecoEsp.idEcosistema;
            this.idEspecie = ecoEsp.idEspecie;
            this.loHabita = ecoEsp.LoHabita;
        }

        public EcosistemaEspecieDTO(int idEcosistema, EcosistemaDTO? ecosistema, int idEspecie, EspecieDTO? especie, bool loHabita)
        {
            this.idEcosistema = idEcosistema;
            this.ecosistema = ecosistema;
            this.idEspecie = idEspecie;
            this.especie = especie;
            this.loHabita = loHabita;
        }
    }
}
