using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EcoMarino.AccesoDatos.EntityFramework.SQL
{
    public class UsuarioRepoSQL : IRepositorioUsuario
    {
        private EcoMarinoContext _context;
        public UsuarioRepoSQL()
        {
            _context = new EcoMarinoContext();
        }

        public void Add(Usuario obj)
        {
            if (!ExisteUser(obj.Alias))
            {
                _context.Add(obj);
                _context.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese alias.");
            }
        }

        public void Delete(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUserPorAlias(string alias)
        {
            if (ExisteUser(alias))
            {
                return _context.Usuarios.Where(user => user.Alias == alias).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public Usuario GetUserPorLogin(string unAlias, string pass)
        {
            Usuario Encontrado = GetUserPorAlias(unAlias);
            if(unAlias == "admin1" && pass == "Admin12")
            {
                return _context.Usuarios.Where(user => user.Alias == unAlias && user.PassNormal == pass).FirstOrDefault();
            }


            if (Encontrado != null)
            {
                string passDesencriptada = Seguridad.Desencriptar(Encontrado.PassEncriptada);
                return _context.Usuarios.Where(user => user.Alias == unAlias && passDesencriptada == pass).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public bool ExisteUser(string alias)
        {
            return _context.Usuarios.Any(u => u.Alias == alias);
        }
    }
}
