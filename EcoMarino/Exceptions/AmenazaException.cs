using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class AmenazaException : Exception
    {
        #region Constructores
        public AmenazaException() : base("Error al crear la amenaza")
        {

        }

        public AmenazaException(string message) : base(message)
        {

        }

        public AmenazaException(string message, Exception inner) : base(message)
        {

        }
        #endregion

    }
}
