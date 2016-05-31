using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Guldborgen.Booking.Common
{
    public class StringHelpers
    {
        public static string EncodeToSha1(string value)
        {
            var hash = SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}