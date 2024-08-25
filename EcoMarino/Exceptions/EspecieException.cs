using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class EspecieException : Exception
    {
        #region Constructores
        public EspecieException() : base("Error al crear la especie")
        {

        }

        public EspecieException(string message) : base(message)
        {

        }

        public EspecieException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
