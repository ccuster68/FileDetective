using System;
using System.Collections.Generic;
using System.Text;

namespace FileChecker.Matchers
{
    public abstract class FileTypeMatcher
    {
        public bool Matches(byte[] bytes, bool resetPosition = true)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            return Matches(bytes);
        }

        protected abstract bool Matches(byte[] bytes);
    }
}
