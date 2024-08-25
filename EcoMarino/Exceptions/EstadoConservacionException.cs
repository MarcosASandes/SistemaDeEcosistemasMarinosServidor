using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class EstadoConservacionException : Exception
    {
        #region Constructores
        public EstadoConservacionException() : base("Error al crear el estado de conservación")
        {

        }

        public EstadoConservacionException(string message) : base(message)
        {

        }

        public EstadoConservacionException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
