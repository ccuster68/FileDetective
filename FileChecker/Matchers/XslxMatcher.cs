using System;
using System.IO;
using System.IO.Packaging;

namespace FileChecker.Matchers
{
    public class XslxMatcher : FileTypeMatcher
    {
        private readonly StartAndEndMatcher _seMatcher;

        public XslxMatcher(StartAndEndMatcher seMatcher)
        {
            _seMatcher = seMatcher;
        }

        protected override bool Matches(byte[] bytes)
        {
            var package = Package.Open(new MemoryStream(bytes));
            if (_seMatcher.Matches(bytes) && package.PartExists(new Uri("/xl/workbook.xml", UriKind.Relative)))
                return true;

            return false;
        }
    }
}
