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
    public class EspecieRepoSQL : IRepositorioEspecie
    {
        private EcoMarinoContext _context;
        private IRepositorioConfiguracion config;
        public EspecieRepoSQL(IRepositorioConfiguracion config)
        {
            _context = new EcoMarinoContext();
            this.config = config;
        }

        public void Add(Especie especie)
        {
            try
            {
                especie.Validar(config);
                _context.Add(especie);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Especie obj)
        {
            throw new NotImplementedException();
        }

        public List<Especie> FindAll()
        {
            return _context.Especies.Include(nameof(Especie.Estado)).Include(nameof(Especie.PesoLong)).Include(nameof(Especie._amenazas)).Include(nameof(Especie._ecosistemas)).Include(nameof(Especie._imagenes)).ToList();
        }

        public Especie FindById(int id)
        {
            return _context.Especies.Where(e => e.Id == id).Include(nameof(Especie.Estado)).FirstOrDefault();
        }

        public List<Especie> GetEspeciePorEcosistema(Ecosistema unEcosistema)
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciePorNombre(string unNombre)
        {
            return _context.Especies.Where(e => e.NombreCientifico == unNombre).Include(nameof(Especie.PesoLong)).Include(nameof(Especie._amenazas)).Include(nameof(Especie._ecosistemas)).Include(nameof(Especie.Estado)).ToList();
        }

        public List<Especie> GetEspeciesEnPeligroDeExtincion()
        {
            try
            {
                List<Especie> allEspecies = FindAll();
                List<Especie> retorno = new List<Especie>();
                if (allEspecies != null)
                {
                    foreach (Especie es in allEspecies)
                    {
                        List<Amenaza> amenazasDeEspecie = _context.EspecieAmenaza.Where(e => e.idEspecie == es.Id).Include(nameof(EspecieAmenaza.Amenaza)).Select(am => am.Amenaza).ToList();
                        List<Ecosistema> ecosistemasQueHabita = _context.EcosistemaEspecie.Where(eco => eco.idEspecie == es.Id && eco.LoHabita).Include(nameof(EcosistemaEspecie.Ecosistema)).Select(e => e.Ecosistema).ToList();
                        if (es.NivelConservacion < 60 || amenazasDeEspecie.Count > 3 || EsAmenazante(ecosistemasQueHabita))
                        {
                            retorno.Add(es);
                        }
                    }
                }
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EsAmenazante(List<Ecosistema> ecosistemas)
        {
            bool ret = false;
            foreach (Ecosistema e in ecosistemas)
            {
                List<EcosistemaAmenaza> amenazasEco = _context.Ecosistemas.Where(eco => eco.Id == e.Id).Include(nameof(Ecosistema._amenazas)).SelectMany(ecosistema => ecosistema._amenazas).ToList();
                if (e.NivelConservacion < 60)
                {
                    if (amenazasEco.Count > 3)
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }


        public List<Especie> GetEspeciesPorRangoPeso(double pesoMinimo, double pesoMaximo)
        {
            return _context.Especies.Where(e => e.PesoLong.Peso <= pesoMaximo && e.PesoLong.Peso >= pesoMinimo).Include(nameof(Especie.PesoLong)).Include(nameof(Especie._amenazas)).Include(nameof(Especie._ecosistemas)).Include(nameof(Especie.Estado)).ToList();
        }

        public List<Especie> GetEspeciesPorNombreYPeso(string nombre, double pesoMinimo, double pesoMaximo)
        {
            return _context.Especies.Where(e => e.PesoLong.Peso <= pesoMaximo && e.PesoLong.Peso >= pesoMinimo && e.NombreCientifico == nombre).Include(nameof(Especie.PesoLong)).Include(nameof(Especie._amenazas)).Include(nameof(Especie._ecosistemas)).Include(nameof(Especie.Estado)).ToList();
        }

        public void Update(Especie obj)
        {
            try
            {
                List<EspecieAmenaza> aux = new List<EspecieAmenaza>();
                aux.AddRange(obj._amenazas);

                foreach (EspecieAmenaza ea in aux)
                {
                    if (_context.EspecieAmenaza.Contains(ea))
                    {
                        throw new EcosistemaException("La amenaza ya está incluida en la especie.");
                    }
                }
                obj.Validar(config);
                _context.Especies.Update(obj);
                _context.SaveChanges();

            }
            catch (EspecieException espException)
            {
                throw espException;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error en la base de datos, reintente." + sqlEx.Message);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("El ecosistema ya está agregado.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public List<Ecosistema> GetEcosistemasDeEspecie(int idEsp)
        {
            List<Ecosistema> Ecos = _context.EcosistemaEspecie.Where(e => e.idEspecie == idEsp && e.LoHabita).Include(nameof(EcosistemaEspecie.Ecosistema)).Select(e => e.Ecosistema).ToList();

            return Ecos;
        }

        public List<Ecosistema> GetEcosistemasHabitables(int idEsp)
        {
            List<EcosistemaEspecie> Ecos = _context.EcosistemaEspecie.Where(e => e.idEspecie == idEsp && !e.LoHabita).Include(nameof(EcosistemaEspecie.Ecosistema)).ToList();
            List<Ecosistema> ecosDeLaEspecie = new List<Ecosistema>();

            foreach (EcosistemaEspecie e in Ecos)
            {
                ecosDeLaEspecie.Add(e.Ecosistema);
            }

            return ecosDeLaEspecie;
        }

        public List<string> GetImagenesDeEspecie(int idEsp)
        {
            List<EspecieImagen> auxEspecies = _context.EspecieImagen.Where(e => e.IdEspecie == idEsp).ToList();
            List<string> ret = new List<string>();
            foreach (EspecieImagen e in auxEspecies)
            {
                ret.Add(e.ruta);
            }

            return ret;
        }

        public string GetPrimerImagen(int idEsp)
        {
            try
            {
                EspecieImagen unaEsp = _context.EspecieImagen.Where(e => e.IdEspecie == idEsp && e.ruta.Contains("001")).FirstOrDefault();
                if (unaEsp != null)
                {
                    return unaEsp.ruta;
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
    }
}
