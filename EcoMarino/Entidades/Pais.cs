using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    [Display(Name = "País")]
    public class Pais : IValidable
    {
        #region Atributos
        [Required]
        public string Nombre { get; set; }

        [Key]
        [Display(Name = "Código alpha")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "Largo del código: entre 2 y 50 caracteres")]
        public string CodigoAlpha { get; set; }
        #endregion

        #region Constructores
        public Pais()
        {
            
        }

        public Pais(string nombre, string codigoAlpha)
        {
            Nombre = nombre;
            CodigoAlpha = codigoAlpha;
        }
        #endregion

        #region Validación
        public void Validar(IRepositorioConfiguracion config)
        {
            try
            {
                ValidarNombre(config);
                ValidarAlpha();
            }
            catch (PaisException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNombre(IRepositorioConfiguracion config)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new PaisException("El nombre es incorrecto.");
            }
            else
            {
                if(Nombre.Length < 2 || Nombre.Length > 50)
                {
                    throw new PaisException("El nombre debe tener entre 2-50 carácteres.");
                }
            }
        }

        private void ValidarAlpha()
        {
            if (string.IsNullOrEmpty(CodigoAlpha))
            {
                throw new PaisException("El código alpha es incorrecto.");
            }
            else
            {
                if (CodigoAlpha.Length < 2 || CodigoAlpha.Length > 4)
                {
                    throw new PaisException("El código alpha debe tener entre 2-4 carácteres.");
                }
            }
        }
        #endregion
    }
}
