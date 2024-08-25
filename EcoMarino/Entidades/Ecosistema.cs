using EcoMarino.Exceptions;
using EcoMarino.InterfacesEntidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.ValueObjects;
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
    public class Ecosistema : IValidable
    {
        #region Atributos
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Ubicación geográfica")]
        public UbicacionGeograficaVO Ubicacion { get; set; }

        [Required]
        public string Descripcion { get; set; }

        
        [ForeignKey(nameof(Estado))] public int IdEstado { get; set; }
        public EstadoConservacion Estado { get; set; }

        [Required]
        [Display(Name = "País")]
        [ForeignKey(nameof(PaisResponsable))] public string CodigoAlpha { get; set; }
        public Pais PaisResponsable { get; set; }

        [Required]
        [Display(Name = "Nivel de conservación")]
        [Range(1, 100, ErrorMessage = "El nivel de conservación debe estar entre 1 y 100")]
        public int NivelConservacion { get; set; }

        public List<EcosistemaEspecie> _especies = new List<EcosistemaEspecie>();
        public List<EcosistemaImagen> _imagenes = new List<EcosistemaImagen>();
        public List<EcosistemaAmenaza>? _amenazas = new List<EcosistemaAmenaza>();
        #endregion

        #region Constructores
        public Ecosistema()
        {
            
        }

        public Ecosistema(string nombre, UbicacionGeograficaVO ubicacion, string descripcion, EstadoConservacion estado, Pais paisResponsable, int nivelConservacion)
        {
            Nombre = nombre;
            Ubicacion = ubicacion;
            Descripcion = descripcion;
            Estado = estado;
            PaisResponsable = paisResponsable;
            NivelConservacion = nivelConservacion;
        }
        #endregion

        #region Validación
        public void Validar(IRepositorioConfiguracion config)
        {
            try
            {
                ValidarNombre(config);
                ValidarUbicacion();
                ValidarDescripcion(config);
                ValidarEstado();
                ValidarPais();
                ValidarNivel();
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

        private void ValidarNombre(IRepositorioConfiguracion config)
        {
            if (Nombre.Length < config.GetTopeInferior("EcosistemaNombre") || Nombre.Length > config.GetTopeSuperior("EcosistemaNombre"))
            {
                throw new EcosistemaException("El nombre (Ecosistema) debe tener entre " + config.GetTopeInferior("EcosistemaNombre") + " y " + config.GetTopeSuperior("EcosistemaNombre"));
            }
        }

        private void ValidarUbicacion()
        {
            if(Ubicacion == null)
            {
                throw new EcosistemaException("Debe especificar una ubicación geográfica.");
            }
            else
            {
                try
                {
                    Ubicacion.Validar();
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
        }

        private void ValidarDescripcion(IRepositorioConfiguracion config)
        {
            if (Descripcion.Length < config.GetTopeInferior("EcosistemaDescripcion") || Descripcion.Length > config.GetTopeSuperior("EcosistemaDescripcion"))
            {
                throw new EcosistemaException("La descripcion (Ecosistema) debe tener entre " + config.GetTopeInferior("EcosistemaDescripcion") + " y " + config.GetTopeSuperior("EcosistemaDescripcion"));
            }
        }

        private void ValidarEstado()
        {
            if (IdEstado == null)
            {
                throw new EcosistemaException("Debe especificar un estado de conservación.");
            }
        }

        private void ValidarPais()
        {
            if (CodigoAlpha == null)
            {
                throw new EcosistemaException("Debe especificar un país responsable del ecosistema.");
            }
        }

        private void ValidarNivel()
        {
            if (NivelConservacion < 1 || NivelConservacion > 100)
            {
                throw new EstadoConservacionException("El nivel de conservación debe ser un número entre 1-10");
            }
        }
        #endregion

        #region Métodos Add de listas
        public void AgregarAmenaza(Amenaza unaAmenaza, IRepositorioConfiguracion config)
        {
            try
            {
                unaAmenaza.ValidarGradoPeligro();
                EcosistemaAmenaza nuevaAmenaza = new EcosistemaAmenaza(this.Id, unaAmenaza.Id, unaAmenaza);
                _amenazas.Add(nuevaAmenaza);
            }
            catch (AmenazaException AmEx)
            {
                throw new AmenazaException("Ha ocurrido un error: ", AmEx);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarEspecie(Especie unaEspecie, IRepositorioConfiguracion config)
        {
            try
            {
                unaEspecie.Validar(config);
                EcosistemaEspecie nuevaEsp = new EcosistemaEspecie(this.Id, unaEspecie.Id, true);
                _especies.Add(nuevaEsp);
            }
            catch (EspecieException AmEx)
            {
                throw new EspecieException("Ha ocurrido un error: ", AmEx);
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
                    EcosistemaImagen nuevaImagen = new EcosistemaImagen(this.Id, ruta);
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
