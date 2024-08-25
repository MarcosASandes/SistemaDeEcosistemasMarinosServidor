using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class ControlDeCambiosException : Exception
    {
        #region Constructores
        public ControlDeCambiosException() : base("Error al crear un control de cambios")
        {

        }

        public ControlDeCambiosException(string message) : base(message)
        {

        }

        public ControlDeCambiosException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
