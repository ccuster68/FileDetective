using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileCheckerTests.Properties;
using System.Linq;

namespace FileChecker.Tests
{
    [TestClass()]
    public class FileCheckerTests
    {
        [TestMethod()]
        public void DocxTest()
        {
            var checker = new FileChecker();
            var fileTypes = checker.GetFileTypes(Resources.v12_docx);
            Assert.AreEqual(".docx", fileTypes.FirstOrDefault().Extension);
        }

        [TestMethod()]
        public void DocxReversTest()
        {
            var checker = new FileChecker();
            var fileTypes = checker.GetFileTypes(Resources._2010_pptx);
            Assert.AreNotEqual(".docx", fileTypes.FirstOrDefault().Extension);
        }

        [TestMethod()]
        public void XlsxTest()
        {
            var checker = new FileChecker();
            var fileTypes = checker.GetFileTypes(Resources._2010_xlsx);
            Assert.AreEqual(".xlsx", fileTypes.FirstOrDefault().Extension);
        }

        [TestMethod()]
        public void PptxTest()
        {
            var checker = new FileChecker();
            var fileTypes = checker.GetFileTypes(Resources._2010_pptx);
            Assert.AreEqual(".pptx", fileTypes.FirstOrDefault().Extension);
        }
    }
}