using System;
using System.IO;
using System.IO.Packaging;

namespace FileChecker.Matchers
{
    public class PptxMatcher:FileTypeMatcher
    {
        private readonly StartAndEndMatcher _seMatcher;

        public PptxMatcher(StartAndEndMatcher seMatcher)
        {
            _seMatcher = seMatcher;
        }

        protected override bool Matches(byte[] bytes)
        {
            var package = Package.Open(new MemoryStream(bytes));
            if (_seMatcher.Matches(bytes) && package.PartExists(new Uri("/ppt/presentation.xml", UriKind.Relative)))
                return true;

            return false;
        }
    }
}
