using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EspecieDTO
    {
        public int id { get; set; }
        public string nombreCientifico { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double peso { get; set; }
        public double longitud { get; set; }
        public EstadoDTO? estado { get; set; }
        public int idEstado { get; set; }
        public int nivelConservacion { get; set; }
        public List<EspecieAmenazaDTO>? _amenazas { get; set; }
        public List<EspecieImagenDTO>? _imagenes { get; set; }
        public List<EcosistemaEspecieDTO>? _ecosistemas { get; set; }

        public EspecieDTO()
        {
            this._amenazas = new List<EspecieAmenazaDTO>();
            this._imagenes = new List<EspecieImagenDTO>();
            this._ecosistemas = new List<EcosistemaEspecieDTO>();
        }

        public EspecieDTO(Especie e)
        {
            this.id = e.Id;
            this.nombreCientifico = e.NombreCientifico;
            this.nombre = e.Nombre;
            this.descripcion = e.Descripcion;
            this.peso = e.PesoLong.Peso;
            this.longitud = e.PesoLong.Longitud;
            EstadoDTO estado = new EstadoDTO(e.Estado);
            this.estado = estado;
            this.idEstado = e.IdEstado;
            this.nivelConservacion = e.NivelConservacion;
            this._amenazas = new List<EspecieAmenazaDTO>();
            this._imagenes = new List<EspecieImagenDTO>();
            this._ecosistemas = new List<EcosistemaEspecieDTO>();
        }

        public EspecieDTO(Especie e, int est)
        {
            this.id = e.Id;
            this.nombreCientifico = e.NombreCientifico;
            this.nombre = e.Nombre;
            this.descripcion = e.Descripcion;
            this.peso = e.PesoLong.Peso;
            this.longitud = e.PesoLong.Longitud;
            this.idEstado = e.IdEstado;
            this.nivelConservacion = e.NivelConservacion;
            this._amenazas = new List<EspecieAmenazaDTO>();
            this._imagenes = new List<EspecieImagenDTO>();
            this._ecosistemas = new List<EcosistemaEspecieDTO>();
        }

        public EspecieDTO(int id, string nombreCientifico, string nombre, string descripcion, double peso, double longitud, EstadoDTO estado, int idEstado, int nivelConservacion)
        {
            this.id = id;
            this.nombreCientifico = nombreCientifico;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.peso = peso;
            this.longitud = longitud;
            this.estado = estado;
            this.idEstado = idEstado;
            this.nivelConservacion = nivelConservacion;
            this._amenazas = new List<EspecieAmenazaDTO>();
            this._imagenes = new List<EspecieImagenDTO>();
            this._ecosistemas = new List<EcosistemaEspecieDTO>();
        }

        public void AgregarEcosistemaNoHabita(EcosistemaDTO e)
        {
            try
            {
                EcosistemaEspecieDTO ecoDto = new EcosistemaEspecieDTO();
                ecoDto.idEcosistema = e.id;
                ecoDto.idEspecie = this.id;
                ecoDto.loHabita = false;
                this._ecosistemas.Add(ecoDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AgregarEcosistemaHabita(EcosistemaDTO e)
        {
            try
            {
                EcosistemaEspecieDTO ecoDto = new EcosistemaEspecieDTO();
                ecoDto.idEcosistema = e.id;
                ecoDto.idEspecie = this.id;
                ecoDto.loHabita = true;
                this._ecosistemas.Add(ecoDto);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AgregarAmenaza(AmenazaDTO am)
        {
            try
            {
                EspecieAmenazaDTO espAm = new EspecieAmenazaDTO();
                espAm.idAmenaza = am.id;
                espAm.idEspecie = this.id;

                this._amenazas.Add(espAm);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarImagen(EspecieImagenDTO img)
        {
            try
            {
                this._imagenes.Add(img);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
