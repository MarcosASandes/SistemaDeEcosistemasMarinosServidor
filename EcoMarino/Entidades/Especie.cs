using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Entidades
{
    public class Especie : IValidable
    {
        #region Atributos
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre científico")]
        public string NombreCientifico { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Peso y longitud")]
        public PesoLongEspecieVO PesoLong { get; set; }
        [Required]
        [ForeignKey(nameof(Estado))] public int IdEstado { get; set; }
        public EstadoConservacion Estado { get; set; }

        [Required]
        [Display(Name = "Nivel de conservación")]
        [Range(1, 100, ErrorMessage = "El nivel de conservación debe estar entre 1 y 100")]
        public int NivelConservacion { get; set; }

        public List<EspecieImagen> _imagenes = new List<EspecieImagen>();
        public List<EspecieAmenaza> _amenazas = new List<EspecieAmenaza>();
        public List<EcosistemaEspecie> _ecosistemas = new List<EcosistemaEspecie>();
        #endregion

        #region Constructores
        public Especie()
        {
            
        }

        public Especie(string nombreCientifico, string nombre, string descripcion, PesoLongEspecieVO pesoLong, EstadoConservacion estado, int nivelConservacion)
        {
            NombreCientifico = nombreCientifico;
            Nombre = nombre;
            Descripcion = descripcion;
            PesoLong = pesoLong;
            Estado = estado;
            NivelConservacion = nivelConservacion;
        }
        #endregion

        #region Validación
        public void Validar(IRepositorioConfiguracion config)
        {
            try
            {
                ValidarNombreCientifico(config);
                ValidarNombre(config);
                ValidarDescripcion(config);
                ValidarEstado();
                ValidarPesoLong(config);
                ValidarNivel();
            }
            catch (EspecieException)
            {
                throw;
            }
            catch (EcosistemaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNombreCientifico(IRepositorioConfiguracion config)
        {
            if (string.IsNullOrEmpty(NombreCientifico))
            {
                throw new EspecieException("El nombre científico es incorrecto.");
            }
            else
            {
                if (NombreCientifico.Length < config.GetTopeInferior("EspecieNombreCientifico") || NombreCientifico.Length > config.GetTopeSuperior("EspecieNombreCientifico"))
                {
                    throw new EspecieException("El nombre cientifico (Especie) debe tener entre " + config.GetTopeInferior("EspecieNombreCientifico") + " y " + config.GetTopeSuperior("EspecieNombreCientifico"));
                }
            }
        }

        private void ValidarNombre(IRepositorioConfiguracion config)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new EspecieException("El nombre es incorrecto.");
            }
            else
            {
                if (Nombre.Length < config.GetTopeInferior("EspecieNombre") || Nombre.Length > config.GetTopeSuperior("EspecieNombre"))
                {
                    throw new EspecieException("El nombre (Especie) debe tener entre " + config.GetTopeInferior("EspecieNombre") + " y " + config.GetTopeSuperior("EspecieNombre"));
                }
            }
        }

        private void ValidarDescripcion(IRepositorioConfiguracion config)
        {
            if (Descripcion.Length < config.GetTopeInferior("EspecieDescripcion") || Descripcion.Length > config.GetTopeSuperior("EspecieDescripcion"))
            {
                throw new EspecieException("La descripcion (Especie) debe tener entre " + config.GetTopeInferior("EspecieDescripcion") + " y " + config.GetTopeSuperior("EspecieDescripcion"));
            }
        }

        private void ValidarEstado()
        {
            if (IdEstado == null)
            {
                throw new EspecieException("Debe especificar un estado de conservación.");
            }
        }

        private void ValidarPesoLong(IRepositorioConfiguracion config)
        {
            if (PesoLong == null)
            {
                throw new EspecieException("Debe especificar un peso y una longitud de esta especie.");
            }
            else
            {
                try
                {
                    PesoLong.Validar();
                }
                catch (EspecieException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void ValidarNivel()
        {
            if (NivelConservacion < 0 || NivelConservacion > 100)
            {
                throw new EstadoConservacionException("El nivel de conservación debe ser un número entre 0-10");
            }
        }
        #endregion

        #region Métodos Add de listas
        public void AgregarAmenaza(Amenaza amenaza, IRepositorioConfiguracion config)
        {
            try
            {
                amenaza.ValidarGradoPeligro();
                EspecieAmenaza unaEspAm = new EspecieAmenaza(this.Id, amenaza.Id, amenaza);
                _amenazas.Add(unaEspAm);

            }
            catch (AmenazaException e)
            {
                throw new AmenazaException("No se pudo agregar la Amenaza a la Especie:" + e.Message);
            }

        }

        public void AgregarEcosistemaHabitable(Ecosistema unEco, IRepositorioConfiguracion config)
        {
            try
            {
                unEco.Validar(config);
                EcosistemaEspecie unaEspEco = new EcosistemaEspecie(unEco.Id, this.Id, false);
                _ecosistemas.Add(unaEspEco);

			}
            catch (Exception)
            {

                throw;
            }
        }

        public void AgregarImagen(string ruta)
        {
            try
            {
                if (!string.IsNullOrEmpty(ruta))
                {
                    EspecieImagen nuevaImagen = new EspecieImagen(this.Id, ruta);
                    _imagenes.Add(nuevaImagen);
                }
                else
                {
                    throw new Exception("La imagen es nula.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
