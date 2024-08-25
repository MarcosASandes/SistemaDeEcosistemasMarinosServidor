using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class UsuarioException : Exception
    {
        #region Constructores
        public UsuarioException() : base("Error al crear el usuario")
        {

        }

        public UsuarioException(string message) : base(message)
        {

        }

        public UsuarioException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
