using EcoMarino.Enum;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    public class EstadoConservacion : IValidable
    {
        #region Atributos
        public int Id { get; set; }
        [Required]
        public NombreEstadoEnum Nombre { get; set; }
        #endregion

        #region Constructores
        public EstadoConservacion()
        {

        }

        public EstadoConservacion(int nivelConservacion)
        {
            this.Nombre = SetNombre(nivelConservacion);

        }
        #endregion

      

        public NombreEstadoEnum SetNombre(int NivelConservacion)
        {
            NombreEstadoEnum NombreRet;
            if (NivelConservacion >= 1 && NivelConservacion <= 100)
            {
                if (NivelConservacion >= 95)
                {
                    NombreRet = NombreEstadoEnum.Optimo;
                }
                else if (NivelConservacion >= 60)
                {
                    NombreRet = NombreEstadoEnum.Aceptable;
                }
                else
                {
                    NombreRet = NombreEstadoEnum.Deficiente;
                }
            }
            else
            {
                throw new EstadoConservacionException();
            }

            return NombreRet;
        }

        public void Validar(IRepositorioConfiguracion config)
        {
            
        }
    }
}
