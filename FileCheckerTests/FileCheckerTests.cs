using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileCheckerTests.Properties;
using System.Linq;

namespace FileChecker.Tests
{
    [TestClass()]
    public class FileCheckerTests
    {
        [TestMethod()]
        public void GetFileTypeTest()
        {
            var checker = new FileChecker();
            var fileTypes = checker.GetFileTypes(Resources.v12_docx);
            Assert.AreEqual("Microsoft Word", fileTypes.FirstOrDefault().Name);
        }
    }
}