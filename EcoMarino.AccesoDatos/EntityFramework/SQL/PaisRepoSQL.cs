using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class PaisRepoSQL : IRepositorioPais
    {
        private EcoMarinoContext _context;
        private IRepositorioConfiguracion config;
        public PaisRepoSQL(IRepositorioConfiguracion config)
        {
            _context = new EcoMarinoContext();
            this.config = config;
        }
        public void Add(Pais obj)
        {
            try
            {
                obj.Validar(config);
                _context.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Pais obj)
        {
            throw new NotImplementedException();
        }

        public List<Pais> FindAll()
        {
            return _context.Paises.ToList();
        }

        public Pais FindByCod(string id)
        {
            return _context.Paises.Where(p => p.CodigoAlpha == id).FirstOrDefault();
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
