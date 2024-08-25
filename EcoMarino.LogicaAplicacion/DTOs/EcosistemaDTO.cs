using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class EcosistemaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string descripcion { get; set; }
        public int nivelConservacion { get; set; }
        public EstadoDTO? estado { get; set; }
        public int idEstado { get; set; }
        public PaisDTO? paisResponsable { get; set; }
        public string? codigoAlpha { get; set; }
        public List<EcosistemaAmenazaDTO>? _amenazas { get; set; }
        public List<EcosistemaEspecieDTO>? _especies { get; set; }
        public List<EcosistemaImagenDTO>? _imagenes { get; set; }


        public EcosistemaDTO()
        {
            this._amenazas = new List<EcosistemaAmenazaDTO>();
            this._especies = new List<EcosistemaEspecieDTO>();
            this._imagenes = new List<EcosistemaImagenDTO>();
        }

        public EcosistemaDTO(Ecosistema eco)
        {
            this.id = eco.Id;
            this.nombre = eco.Nombre;
            this.latitud = eco.Ubicacion.Latitud;
            this.longitud = eco.Ubicacion.Longitud;
            this.descripcion = eco.Descripcion;
            this.nivelConservacion = eco.NivelConservacion;
            EstadoDTO es = new EstadoDTO(eco.Estado);
            this.estado = es;
            this.idEstado = eco.IdEstado;
            PaisDTO p = new PaisDTO(eco.PaisResponsable);
            this.paisResponsable = p;
            this.codigoAlpha = p.codigoAlpha;
            this._amenazas = new List<EcosistemaAmenazaDTO>();
            this._especies = new List<EcosistemaEspecieDTO>();
            this._imagenes = new List<EcosistemaImagenDTO>();
        }

        public EcosistemaDTO(Ecosistema eco, int est)
        {
            this.id = eco.Id;
            this.nombre = eco.Nombre;
            this.latitud = eco.Ubicacion.Latitud;
            this.longitud = eco.Ubicacion.Longitud;
            this.descripcion = eco.Descripcion;
            this.nivelConservacion = eco.NivelConservacion;
            this.idEstado = eco.IdEstado;
            this.codigoAlpha = eco.CodigoAlpha;
            this._amenazas = new List<EcosistemaAmenazaDTO>();
            this._especies = new List<EcosistemaEspecieDTO>();
            this._imagenes = new List<EcosistemaImagenDTO>();
        }

        public EcosistemaDTO(int id, string nombre, double latitud, double longitud, string descripcion, int nivelConservacion, EstadoDTO estado, PaisDTO paisResponsable, int idestado, string codAlpha)
        {
            this.id = id;
            this.nombre = nombre;
            this.latitud = latitud;
            this.longitud = longitud;
            this.descripcion = descripcion;
            this.nivelConservacion = nivelConservacion;
            this.estado = estado;
            this.idEstado = idestado;
            this.paisResponsable = paisResponsable;
            this.codigoAlpha = codAlpha;
            this._amenazas = new List<EcosistemaAmenazaDTO>();
            this._especies = new List<EcosistemaEspecieDTO>();
            this._imagenes = new List<EcosistemaImagenDTO>();
        }

        public void AgregarEspecieHabita(EspecieDTO esp)
        {
            try
            {
                EcosistemaEspecieDTO ecoEsp = new EcosistemaEspecieDTO();
                ecoEsp.idEspecie = esp.id;
                ecoEsp.idEcosistema = this.id;
                ecoEsp.loHabita = true;

                this._especies.Add(ecoEsp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarEspecieNoHabita(EspecieDTO esp)
        {
            try
            {
                EcosistemaEspecieDTO ecoEsp = new EcosistemaEspecieDTO();
                ecoEsp.idEspecie = esp.id;
                ecoEsp.idEcosistema = this.id;
                ecoEsp.loHabita = false;

                this._especies.Add(ecoEsp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarAmenaza(AmenazaDTO am)
        {
            try
            {
                EcosistemaAmenazaDTO espAm = new EcosistemaAmenazaDTO();
                espAm.amenazaId = am.id;
                espAm.ecosistemaId = this.id;

                this._amenazas.Add(espAm);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarImagen(EcosistemaImagenDTO img)
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
