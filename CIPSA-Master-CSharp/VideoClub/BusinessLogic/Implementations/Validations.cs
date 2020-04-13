using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoClub.Common.Exceptions;

namespace VideoClub.BusinessLogic.Implementations
{
    public class Validations
    {
        public static void ValidateStringClient(string value)
        {
            var regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(value))
                throw new InvalidateStringClientException(value);

        }
        public static void ValidatePhoneNumberClient(string value)
        {
            var regex = new Regex("^34 ?(?:6[0-9]{2}|7[0-9][0-9])(?: ?[0-9]{3}){2}\r?$");

            if (!regex.IsMatch(value))
                throw new InvalidatePhoneNumberException();

        }
    }
}
