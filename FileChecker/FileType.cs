using FileChecker.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileChecker
{
    public class FileType
    {
        private static readonly FileType unknown = new FileType("unknown", string.Empty, null);

        private readonly string name;

        private readonly string extension;

        private readonly FileTypeMatcher fileTypeMatcher;

        public string Name { get { return name; } }

        public string Extension { get { return extension; } }

        public static FileType Unknown { get { return unknown; } }

        public FileType(string name, string extension, FileTypeMatcher matcher)
        {
            this.name = name;
            this.extension = extension;
            this.fileTypeMatcher = matcher;
        }

        public bool Matches(byte[] bytes)
        {
            return this.fileTypeMatcher == null || this.fileTypeMatcher.Matches(bytes);
        }
    }
}
