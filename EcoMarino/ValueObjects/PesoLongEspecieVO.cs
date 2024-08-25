using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.ValueObjects
{
    [Owned]
    public class PesoLongEspecieVO
    {
        #region Atributos
        public double Peso { get; set; }
        public double Longitud { get; set; }
        #endregion

        #region Constructores
        public PesoLongEspecieVO()
        {
            
        }

        public PesoLongEspecieVO(double peso, double longitud)
        {
            Peso = peso;
            Longitud = longitud;
        }
        #endregion

        #region Validación
        public void Validar()
        {
            try
            {
                ValidarPeso();
                ValidarLongitud();
            }
            catch (EspecieException)
            {
                throw;
            }
        }

        public void ValidarPeso()
        {
            if(Peso < 0)
            {
                throw new EspecieException("Especifique un peso correcto.");
            }
        }

        public void ValidarLongitud()
        {
            if (Longitud < 0)
            {
                throw new EspecieException("Especifique una longitud correcta.");
            }
        }
        #endregion
    }
}
