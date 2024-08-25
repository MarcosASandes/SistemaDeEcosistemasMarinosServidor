using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class PaisException : Exception
    {
        #region Constructores
        public PaisException() : base("Error al crear el país")
        {

        }

        public PaisException(string message) : base(message)
        {

        }

        public PaisException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
