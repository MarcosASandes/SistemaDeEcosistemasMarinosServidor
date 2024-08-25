using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario GetUserPorLogin(string unAlias, string pass);
        public bool ExisteUser(string alias);

        public Usuario GetUserPorAlias(string alias);
    }
}
