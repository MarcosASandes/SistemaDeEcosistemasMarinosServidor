using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class ConfiguracionRepoSQL : IRepositorioConfiguracion
    {
        private EcoMarinoContext _context;
        public ConfiguracionRepoSQL()
        {
            _context = new EcoMarinoContext();
        }
        public void Add(Configuracion obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Configuracion obj)
        {
            throw new NotImplementedException();
        }

        public List<Configuracion> FindAll()
        {
            return _context.Configuraciones.ToList();
        }
        public Configuracion FindByNombreAtributo(string nombreAtributo)
        {
            return _context.Configuraciones.Where(n => n.NombreAtributo == nombreAtributo).FirstOrDefault();
        }

        public Configuracion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetTopeInferior(string nombreAtributo)
        {
            Configuracion config = _context.Configuraciones.Where(conf => conf.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (config == null)
            {
                throw new Exception("Nombre del atributo incorrecto");
            }
            return config.TopeInferior;
        }

        public int GetTopeSuperior(string nombreAtributo)
        {
            Configuracion config = _context.Configuraciones.Where(conf => conf.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (config == null)
            {
                throw new Exception("Nombre del atributo incorrecto");
            }
            return config.TopeSuperior;
        }

        public void Update(Configuracion config)
        {
            try
            {
                _context.Configuraciones.Update(config);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

