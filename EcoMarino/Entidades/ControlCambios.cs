using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    public class ControlCambios : IValidable
    {
        #region Atributos
        public int Id { get; set; }
        [Required]
        public string? NombreResponsable { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public int IdEntidad { get; set; }
        [Required]
        public string TipoEntidad { get; set; }
       
        #endregion

        #region Constructores
        public ControlCambios()
        {
            
        }

        public ControlCambios(string nombreResponsable, DateTime fechaHora, int idEntidad, string tipoEntidad)
        {
            NombreResponsable = nombreResponsable;
            FechaHora = fechaHora;
            IdEntidad = idEntidad;
            TipoEntidad = tipoEntidad;
        }
        #endregion

        #region Validación
        public void Validar(IRepositorioConfiguracion config)
        {
            try
            {
                ValidarNombreResponsable();
                ValidarFecha();
                ValidarIDEntidad();
                ValidarTipoEntidad();
            }
            catch (ControlDeCambiosException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNombreResponsable()
        {
            if (string.IsNullOrEmpty(NombreResponsable))
            {
                throw new ControlDeCambiosException("El nombre no puede estar vacío.");
            }
        }

        private void ValidarFecha()
        {
            if(FechaHora > DateTime.Now)
            {
                throw new ControlDeCambiosException("La fecha es incorrecta.");
            }
        }

        private void ValidarIDEntidad()
        {
            if(IdEntidad < 0)
            {
                throw new ControlDeCambiosException("Debe especificarse el id de la entidad.");
            }
        }

        private void ValidarTipoEntidad()
        {
            if (string.IsNullOrEmpty(TipoEntidad))
            {
                throw new ControlDeCambiosException("El tipo de la entidad debe especificarse.");
            }
        }
        #endregion
    }
}
