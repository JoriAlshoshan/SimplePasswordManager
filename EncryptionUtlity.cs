using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.ConsoleApp.TrainingApps.PasswordManager
{
    public class EncryptionUtlity
    {
        private static readonly string _originalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly string _altChars = "F2bDHi4YVQu7TUxhmfsq6tkXWL10ZNy9BnSAPIvjgKw3CrzReLEdJ5ca08MGop";
       public static string Encrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (var ch in password)
            {
                var charIndex = _originalChars.IndexOf(ch);
                sb.Append(_altChars[charIndex]);
            }
            return sb.ToString();
        } 
        public static string Decrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (var ch in password)
            {
                var charIndex = _altChars.IndexOf(ch);
                sb.Append(_originalChars[charIndex]);
            }
            return sb.ToString();
        }
    }
}
