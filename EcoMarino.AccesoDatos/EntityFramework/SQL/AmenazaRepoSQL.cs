using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class AmenazaRepoSQL : IRepositorioAmenaza
    {
        private EcoMarinoContext _context;
        public AmenazaRepoSQL()
        {
            _context = new EcoMarinoContext();
        }

        public void Add(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public List<Amenaza> FindAll()
        {
            return _context.Amenazas.ToList();
        }

        public Amenaza FindById(int id)
        {
            return _context.Amenazas.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Update(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public List<Amenaza> GetAmenazasPorEcosistemaId(int idEco)
        {
            List<EcosistemaAmenaza> aux = _context.EcosistemaAmenaza.Where(ea => ea.EcosistemaId == idEco).Include(nameof(EcosistemaAmenaza.Amenaza)).ToList();
            List<Amenaza> ret = new List<Amenaza>();
            foreach(EcosistemaAmenaza a in aux)
            {
                ret.Add(a.Amenaza);
            }

            return ret;
        }

        public List<Amenaza> GetAmenazasPorEspecieId(int idEsp)
        {
            List<EspecieAmenaza> aux = _context.EspecieAmenaza.Where(ea => ea.idEspecie == idEsp).Include(nameof(EspecieAmenaza.Amenaza)).ToList();
            List<Amenaza> ret = new List<Amenaza>();
            foreach (EspecieAmenaza a in aux)
            {
                ret.Add(a.Amenaza);
            }

            return ret;
        }
    }
}
