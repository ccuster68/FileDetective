using FileChecker;
using FileDetective.Properties;
using System;

namespace FileDetective
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new FileChecker.FileChecker();
            var fileTypes = checker.GetFileTypes(Resources.v12_docx);
        }
    }
}
