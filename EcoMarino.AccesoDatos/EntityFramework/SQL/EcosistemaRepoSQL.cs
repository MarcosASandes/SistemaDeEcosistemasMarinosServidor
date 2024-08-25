using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class EcosistemaRepoSQL : IRepositorioEcosistema
    {
        private EcoMarinoContext _context;
        private IRepositorioConfiguracion config;
        public EcosistemaRepoSQL(IRepositorioConfiguracion config)
        {
            _context = new EcoMarinoContext();
            this.config = config;
        }
        public void Add(Ecosistema eco)
        {
            try
            {
                eco.Validar(config);
                _context.Add(eco);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*       
       NECESITARE BORRAR UN ECOSISTEMA, Y NO PUEDO HACERLO SI ESE ECOSISTEMA TIENE IMÁGENES, ENTONCES HARÉ ESTO:
      List<EcosistemaImagen> aux = _context.EcosistemaImagen.Where(e => e.IdEcosistema == unaEspecie.Id).ToList();
          _context.EcosistemaImagen.RemoveRange(aux);
       */

        public void Delete(Ecosistema obj)
        {
            try
            {
                List<EcosistemaImagen> aux = _context.EcosistemaImagen.Where(e => e.IdEcosistema == obj.Id).ToList();
                if (aux.Count > 0)
                {
                    _context.EcosistemaImagen.RemoveRange(aux);
                }
                this._context.Ecosistemas.Remove(obj);
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ecosistema> FindAll()
        {
            return _context.Ecosistemas.Include(nameof(Ecosistema.PaisResponsable)).Include(nameof(Ecosistema.Estado)).Include(nameof(Ecosistema._amenazas)).Include(nameof(Ecosistema._especies)).Include(nameof(Ecosistema._imagenes)).ToList();
        }

        public Ecosistema FindById(int id)
        {
            return _context.Ecosistemas.Where(e => e.Id == id).Include(nameof(Ecosistema.PaisResponsable)).Include(nameof(Ecosistema.Estado)).Include(nameof(Ecosistema._imagenes)).FirstOrDefault();
        }

        public List<Ecosistema> GetEcosistemasInadecuados(Especie unaEspecie)
        {
            List<Ecosistema> allEcosistemas = FindAll();
            List<Ecosistema> paraMostrar = new List<Ecosistema>();
            foreach (Ecosistema e in allEcosistemas)
            {
                paraMostrar.AddRange(ObtenerEcosistemasInadecuados(unaEspecie.Id, e.Id));
            }
            return paraMostrar;
        }

        public List<Ecosistema> ObtenerEcosistemasInadecuados(int idEspecie, int idEco)
        {
            List<Ecosistema> ret = new List<Ecosistema>();
            List<Amenaza> amenazasEspecie = _context.EspecieAmenaza.Where(e => e.idEspecie == idEspecie).Include(nameof(EspecieAmenaza.Amenaza)).Select(am => am.Amenaza).ToList();
            List<Amenaza> amenazasEco = _context.EcosistemaAmenaza.Where(eco => eco.EcosistemaId == idEco).Include(nameof(EcosistemaAmenaza.Amenaza)).Select(am => am.Amenaza).ToList();

            foreach (Amenaza aEsp in amenazasEspecie)
            {
                if (amenazasEco.Contains(aEsp))
                {
                    Ecosistema ecoInadecuado = FindById(idEco);
                    ret.Add(ecoInadecuado);
                }
            }
            return ret;
        }





        public List<Especie> GetEspeciesDeEcosistema(int idEco)
        {

            List<EcosistemaEspecie> EspeciesDelEco = _context.EcosistemaEspecie.Where(e => e.idEcosistema == idEco && e.LoHabita).Include(nameof(EcosistemaEspecie.Especie)).ToList();
            List<Especie> especiesAsociadas = new List<Especie>();

            foreach (EcosistemaEspecie e in EspeciesDelEco)
            {
                especiesAsociadas.Add(e.Especie);
            }
            return especiesAsociadas;
        }

        public List<string> GetImagenesDeEcosistema(int idEco)
        {
            List<EcosistemaImagen> auxEcos = _context.EcosistemaImagen.Where(e => e.IdEcosistema == idEco).ToList();
            List<string> ret = new List<string>();
            foreach (EcosistemaImagen e in auxEcos)
            {
                ret.Add(e.ruta);
            }

            return ret;
        }

        public string GetPrimerImagen(int idEco)
        {
            try
            {
                EcosistemaImagen unEco = _context.EcosistemaImagen.Where(e => e.IdEcosistema == idEco && e.ruta.Contains("001")).FirstOrDefault();
                if (unEco != null)
                {
                    return unEco.ruta;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(Ecosistema obj)
        {
            try
            {
                List<EcosistemaAmenaza> aux = new List<EcosistemaAmenaza>();
                aux.AddRange(obj._amenazas);

                foreach (EcosistemaAmenaza ea in aux)
                {
                    if (_context.EcosistemaAmenaza.Contains(ea))
                    {
                        throw new EcosistemaException("La amenaza ya está incluida en el ecosistema.");
                    }
                }

                obj.Validar(config);
                this._context.Ecosistemas.Update(obj);
                this._context.SaveChanges();
            }
            catch (EcosistemaException ecoException)
            {
                throw ecoException;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error en la base de datos, reintente." + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }


    }
}
