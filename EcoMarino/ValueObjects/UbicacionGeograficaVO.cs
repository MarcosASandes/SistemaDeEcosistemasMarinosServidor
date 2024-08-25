using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.ValueObjects
{
    [Owned]
    public class UbicacionGeograficaVO
    {
        #region Atributos
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        #endregion

        #region Constructores
        public UbicacionGeograficaVO()
        {
            
        }

        public UbicacionGeograficaVO(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
        #endregion

        #region Validación
        public void Validar()
        {
            try
            {
                ValidarLatitud();
                ValidarLongitud();
            }
            catch (EcosistemaException)
            {
                throw;
            }
        }

        public void ValidarLatitud()
        {
            if (Latitud < -90 || Latitud > 90)
            {
                throw new EcosistemaException("Latitud incorrecta.");
            }
        }

        public void ValidarLongitud()
        {
            if (Longitud < -180 || Longitud > 180)
            {
                throw new EcosistemaException("Longitud incorrecta.");
            }
        }
        #endregion

        public override string ToString()
        {
            return $"Lat {Latitud}, Long {Longitud}"; 
        }
    }
}
