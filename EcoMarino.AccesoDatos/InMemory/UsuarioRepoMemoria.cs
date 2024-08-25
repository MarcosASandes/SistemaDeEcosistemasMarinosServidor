using EcoMarino.AccesoDatos.EntityFramework.SQL;
using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class UsuarioRepoMemoria : IRepositorioUsuario
    {

        private static List<Usuario> _usuarios = new List<Usuario>();

        public UsuarioRepoMemoria()
        {
            _usuarios.Add(new Usuario("Admin1", "admin12", true, DateTime.Now));
        }


        public void Add(Usuario obj)
        {
            try
            {
                if (obj != null)
                {
                    //obj.Validar();

                    if (!ExisteUser(obj.Alias))
                    {
                        _usuarios.Add(obj);
                    }
                    else
                    {
                        throw new UsuarioException("Ya existe un usuario con ese alias.");
                    }

                }
                else
                {
                    throw new UsuarioException("Ha ocurrido un error al crear el usuario.");
                }
            }
            catch (UsuarioException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
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


        public Usuario GetUserPorLogin(string unAlias, string pass)
        {
            Usuario unUser = null;
            if (!string.IsNullOrEmpty(unAlias) && !string.IsNullOrEmpty(pass))
            {
                foreach (Usuario us in _usuarios)
                {
                    if (us.PassNormal == pass && us.Alias == unAlias)
                    {
                        unUser = us;
                    }
                }
            }
            return unUser;
        }

        public bool ExisteUser(string alias)
        {
            bool existe = false;
            foreach (Usuario us in _usuarios)
            {
                if (us.Alias == alias)
                {
                    existe = true;
                }
            }
            return existe;
        }

        public Usuario GetUserPorAlias(string alias)
        {
            throw new NotImplementedException();
        }
    }
}
