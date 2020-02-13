using System;
using System.IO;
using System.IO.Packaging;

namespace FileChecker.Matchers
{
    public class DocxMatcher:FileTypeMatcher
    {
        private readonly StartAndEndMatcher _seMatcher;

        public DocxMatcher(StartAndEndMatcher seMatcher)
        {
            _seMatcher = seMatcher;
        }

        protected override bool Matches(byte[] bytes)
        {
            var package = Package.Open(new MemoryStream(bytes));
            if (_seMatcher.Matches(bytes) && package.PartExists(new Uri("/word/document.xml", UriKind.Relative)))
                return true;

            return false;
        }

        private string DetermineMsOfficeType(string file)
        {
            string ext = string.Empty;
            Package package = Package.Open(file);
            if (package.PartExists(new Uri("/word/document.xml", UriKind.Relative)))
            {
                ext = ".docx";
            }
            else if (package.PartExists(new Uri("/xl/workbook.xml", UriKind.Relative)))
            {
                ext = ".xslx";
            }
            else if (package.PartExists(new Uri("/ppt/presentation.xml", UriKind.Relative)))
            {
                ext = ".pptx";
            }

            package.Close();
            return ext;
        }
    }
}
