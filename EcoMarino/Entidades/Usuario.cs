using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoMarino.Entidades
{
    [Index(nameof(Alias), IsUnique = true)]
    public class Usuario : IValidable
    {
        #region Atributos
        public int Id { get; set; }
        [Required]
        public string Alias { get; set; }

        [Required]
        public string PassNormal { get; set; }
        public string PassEncriptada { get; set; }

        public bool EsAdmin { get; set; }
        public DateTime? FechaIngreso { get; set; }
        #endregion

        #region Constructores
        public Usuario()
        {
            
        }

        public Usuario(string alias, string pass, bool esAdmin, DateTime fechaIngreso)
        {
            Alias = alias;
            PassNormal = pass;
            EsAdmin = esAdmin;
            FechaIngreso = fechaIngreso;

        }
        #endregion

        #region Validación
        public void ValidarUsuario()
        {
            try
            {
                ValidarAlias();
                ValidarPass();
            }
            catch (UsuarioException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarAlias()
        {
            if (string.IsNullOrEmpty(Alias))
            {
                throw new UsuarioException("El alias es incorrecto.");
            }
            else
            {
                if (Alias.Length < 6)
                {
                    throw new UsuarioException("El alias debe tener mínimo 6 caracteres");
                }
            }
        }


        private void ValidarPass()
        {
            if (PassNormal.Length < 8)
            {
                throw new UsuarioException("La contraseña debe tener al menos 8 caracteres.");
            }

            bool contieneMayuscula = false;
            bool contieneMinuscula = false;
            bool contieneDigito = false;
            bool contieneCaracterEspecial = false;

            string caracteresEspeciales = ".,#;:!";

            foreach (char c in PassNormal)
            {
                if (char.IsUpper(c))
                {
                    contieneMayuscula = true;
                }
                else if (char.IsLower(c))
                {
                    contieneMinuscula = true;
                }
                else if (char.IsDigit(c))
                {
                    contieneDigito = true;
                }
                else if (caracteresEspeciales.Contains(c))
                {
                    contieneCaracterEspecial = true;
                }
            }

            if (!contieneMayuscula)
            {
                throw new UsuarioException("La contraseña debe contener al menos una letra mayúscula.");
            }

            if (!contieneMinuscula)
            {
                throw new UsuarioException("La contraseña debe contener al menos una letra minúscula.");
            }

            if (!contieneDigito)
            {
                throw new UsuarioException("La contraseña debe contener al menos un dígito.");
            }

            if (!contieneCaracterEspecial)
            {
                throw new UsuarioException("La contraseña debe contener al menos un carácter especial (.,#;:!).");
            }
        }

        public void Validar(IRepositorioConfiguracion config)
        {
           
        }
        #endregion

    }
}
