using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    /*Clase de asociación*/
    public class EcosistemaEspecie
    {
        #region Atributos
        public int idEcosistema { get; set; }
        public Ecosistema? Ecosistema { get; set; }
        public int idEspecie { get; set; }
        public Especie? Especie { get; set; }
        public bool LoHabita { get; set; }
        #endregion

        #region Constructores
        public EcosistemaEspecie() { }

        public EcosistemaEspecie(int EcoId, int EspId, bool loHabita)
        {
            this.idEcosistema = EcoId;
            this.Ecosistema = null;
            this.idEspecie = EspId;
            this.Especie = null;
            this.LoHabita = loHabita;
        }
        public EcosistemaEspecie(int idEco)
        {
            this.idEcosistema = idEco;
        }
        #endregion
    }
}
