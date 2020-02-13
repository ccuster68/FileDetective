using FileChecker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileChecker.Matchers
{
    public class StartAndEndMatcher : FileTypeMatcher
    {
        private readonly string _regexStart;

        private readonly string _regexEnd;

        public StartAndEndMatcher(string regexStart, string regexEnd)
        {
            this._regexStart = regexStart;
            this._regexEnd = regexEnd;
        }

        protected override bool Matches(byte[] bytes)
        {
            var hexStart = bytes.Take(50).ByteArrayToHex();
            var hexEnd = bytes.Skip(bytes.Length - 50).Take(50).ByteArrayToHex();
            if (Regex.Match(hexStart, _regexStart, RegexOptions.IgnoreCase).Success &&
                Regex.Match(hexEnd, _regexEnd, RegexOptions.IgnoreCase).Success)
            {
                return true;
            }
            return false;
        }
    }
}
