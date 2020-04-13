using System;

namespace VideoClub.Core.Common.Exceptions
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
