using System;
using System.Linq;
using System.Text.RegularExpressions;
using VideoClub.Common.Model.Exceptions;

namespace VideoClub.Common.Model.Utils
{
    public class Helper
    {
        public static readonly string Movie = "MOV";
        public static readonly string VideoGame = "GAM";
        public static readonly string Client = "CLI";
        public static readonly string Rental = "RENTAL";
        public static readonly string Separator = "-";

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

        public static string GetCodeNumber(string model, int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

            return model + Separator + result;
        }
    }
}
