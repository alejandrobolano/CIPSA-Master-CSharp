using System.Linq;

namespace CIPSA_CSharp_Module11.Extensions
{
    public static class StringExtension 
    {
        private static readonly char[] Vocals = {'a','e','i','o','u'};

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.</summary>
        /// <param name="oldValue">The string to be replaced. </param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue" />. </param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" />. </returns>
        public static string ReplaceExtension(this string phrase, string oldValue, string newValue)
        {
            return phrase.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Returns the quantity of vocals of a specified string in the current instance
        /// </summary>
        /// <returns>A int that is equivalent to quantity of vocals</returns>
        public static int QuantityVocals(this string value)
        {
            return value.Count(character => Vocals.Contains(character));
        }
    }
}
