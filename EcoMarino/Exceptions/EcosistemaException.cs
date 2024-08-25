using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.Exceptions
{
    public class EcosistemaException : Exception
    {
        #region Constructores
        public EcosistemaException() : base("Error al crear el ecosistema")
        {

        }

        public EcosistemaException(string message) : base(message)
        {

        }

        public EcosistemaException(string message, Exception inner) : base(message)
        {

        }
        #endregion
    }
}
