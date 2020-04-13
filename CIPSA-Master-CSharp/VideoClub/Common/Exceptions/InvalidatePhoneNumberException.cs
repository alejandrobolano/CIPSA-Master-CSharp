using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Common.Exceptions
{
    public class InvalidatePhoneNumberException : Exception
    {
        /// <summary>
        /// Return an exception because is a wrong format of Spain phone number
        /// </summary>
        public InvalidatePhoneNumberException()
            : base($"Número de teléfono incorrecto")
        {

        }
    }
}
