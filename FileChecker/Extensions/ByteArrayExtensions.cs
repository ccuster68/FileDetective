using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileChecker.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ByteArrayToHex(this IEnumerable<byte> ba)
        {
            StringBuilder hex = new StringBuilder(ba.Count() * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
