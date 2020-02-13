﻿using FileChecker.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileChecker
{
    public class FileChecker : IFileTypeChecker
    {
        private readonly IList<FileType> knownFileTypes;

        public FileChecker()
        {
            this.knownFileTypes = new List<FileType>
                {
                    //new FileType("Bitmap", ".bmp", 
                    //    new ExactFileTypeMatcher(new byte[] {0x42, 0x4d})),
                    //new FileType("Portable Network Graphic", ".png",
                    //    new ExactFileTypeMatcher(new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A})),
                    //new FileType("JPEG", ".jpg",
                    //    new FuzzyFileTypeMatcher(new byte?[] {0xFF, 0xD, 0xFF, 0xE0, null, null, 0x4A, 0x46, 0x49, 0x46, 0x00})),
                    //new FileType("Graphics Interchange Format 87a", ".gif",
                    //    new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61})),
                    //new FileType("Graphics Interchange Format 89a", ".gif",
                    //    new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61})),
                    //new FileType("Portable Document Format", ".pdf", 
                    //    new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] { 0x25, 0x50, 0x44, 0x46 }), 1019))
                    // ... Potentially more in future
            
            new FileType("Microsoft Word", ".docx", new StartAndEndMatcher("504B030414000600.*", "504B0506.{36}"))
                };
        }

        public FileChecker(IList<FileType> knownFileTypes)
        {
            this.knownFileTypes = knownFileTypes;
        }

        public FileType GetFileType(byte[] fileContent)
        {
            return GetFileTypes(fileContent).FirstOrDefault() ?? FileType.Unknown;
        }

        public IEnumerable<FileType> GetFileTypes(byte[] bytes)
        {
            return knownFileTypes.Where(fileType => fileType.Matches(bytes));
        }
    }
}
