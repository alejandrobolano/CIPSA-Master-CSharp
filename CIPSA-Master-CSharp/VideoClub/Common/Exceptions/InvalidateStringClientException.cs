using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Common.Exceptions
{
    public class InvalidateStringClientException : Exception
    {
        /// <summary>
        /// Return an exception when the string entered is not just alphabetic string
        /// </summary>
        public InvalidateStringClientException()
            : base($"Invalid string of client")
        {

        }
        /// <summary>
        /// Return an exception when the string entered is not just alphabetic string
        /// </summary>
        /// <param name="value"></param>
        public InvalidateStringClientException(string value)
            : base($"Invalid string of client: {value}")
        {

        }
    }
}
