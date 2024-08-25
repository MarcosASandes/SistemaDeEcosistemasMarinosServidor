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
    public class ControlCambiosRepoSQL : IRepositorioCambios
    {
        private EcoMarinoContext _context;
        private IRepositorioConfiguracion config;
        public ControlCambiosRepoSQL(IRepositorioConfiguracion config)
        {
            _context = new EcoMarinoContext();
            this.config = config;
        }
        public void Add(ControlCambios obj)
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

        public void Delete(ControlCambios obj)
        {
            throw new NotImplementedException();
        }

        public List<ControlCambios> FindAll()
        {
            return _context.ControlCambios.ToList();
        }

        public ControlCambios FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ControlCambios obj)
        {
            throw new NotImplementedException();
        }
    }
}
