using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EcosistemaImagenDTO
    {
        public int id { get; set; }
        public int idEcosistema { get; set; }
        public EcosistemaDTO? eco { get; set; }
        public string ruta { get; set; }


        public EcosistemaImagenDTO() { }

        public EcosistemaImagenDTO(EcosistemaImagen ecoImg)
        {
            this.id = ecoImg.Id;
            this.idEcosistema = ecoImg.IdEcosistema;
            this.ruta = ecoImg.ruta;
        }

        public EcosistemaImagenDTO(int id, int idEcosistema, EcosistemaDTO? eco, string ruta)
        {
            this.id = id;
            this.idEcosistema = idEcosistema;
            this.eco = eco;
            this.ruta = ruta;
        }
    }
}
