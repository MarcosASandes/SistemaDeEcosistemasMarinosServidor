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
    public class Amenaza : IValidable
    {
        #region Atributos
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "El grado de peligro debe estar entre 1 y 10")]
        public int GradoPeligro { get; set; }

        public List<EcosistemaAmenaza> ecosistemas { get; set; } = new List<EcosistemaAmenaza>();
        public List<EspecieAmenaza> especies { get; set; } = new List<EspecieAmenaza>();
        #endregion

        #region Constructores
        public Amenaza()
        {
            
        }

        public Amenaza(string descripcion, int gradoPeligro)
        {
            Descripcion = descripcion;
            GradoPeligro = gradoPeligro;
        }
        #endregion

        #region Validación
        public void Validar(IRepositorioConfiguracion config)
        {
            try
            {
                ValidarDescripcion(config);
                ValidarGradoPeligro();
            }
            catch (AmenazaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarDescripcion(IRepositorioConfiguracion config)
        {
            if (Descripcion.Length < config.GetTopeInferior("AmenazaDescripcion") || Descripcion.Length > config.GetTopeSuperior("AmenazaDescripcion"))
            {
                throw new AmenazaException("La descripcion debe tener entre " + config.GetTopeInferior("AmenazaDescripcion") + "y " + config.GetTopeSuperior("AmenazaDescripcion") + "caracteres.");
            }
        }

        public void ValidarGradoPeligro()
        {
            if(GradoPeligro < 1 || GradoPeligro > 10)
            {
                throw new AmenazaException("El grado de peligro debe ser un número entre 1-10");
            }
        }       
        #endregion
    }
}
