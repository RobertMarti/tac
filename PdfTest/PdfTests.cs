using NUnit.Framework;
using Shouldly;
using tac.Pdf.PdfLibrary;

namespace Pdf.Tests
{
    [TestFixture]
    public class PdfTests
    {
        private const string UrlBlick = "https://www.blick.ch";
        private const string FileBlick = "blick.pdf";
        private const string UrlPost = "https://www.post.ch";
        private const string FilePost = "Post.pdf";
        private const string UrlEiger = "https://tacsc.dev.local/?sc_database=master&sc_itemid=%7B1E02A992-DEC3-4040-A101-3148B4B74915%7D";
        private const string FileEiger = "ClimbEiger.pdf";
        private const string UrlWertsachen = "https://www.post.ch/de/pakete-versenden/wertsachen";
        private const string FileWertsachen = "Wertsachen.pdf";

        [SetUp]
        public void SetUp()
        {
        }

        //[Test]
        //[TestCase(UrlBlick, FileBlick, 1024)]
        //[TestCase(UrlEiger, FileEiger, 1600)]
        //[TestCase(UrlPost, FilePost, 1024)]
        //[TestCase(UrlWertsachen, FileWertsachen, 1024)]
        //public void SelectPdf(string url, string fileName, int width)
        //{
        //    var ok = new tac.Pdf.PdfLibrary.SelectPdf().CreatePdfFile(url, fileName, width);
        //    ok.ShouldBeTrue();
        //}

        [Test]
        //[TestCase(UrlBlick, FileBlick, 1024)]
        [TestCase(UrlEiger, FileEiger, 1600)]
        //[TestCase(UrlPost, FilePost, 1024)]
        //[TestCase(UrlWertsachen, FileWertsachen, 1024)]

        public void PdfWinnovative(string url, string fileName, int width)
        {
            var ok = new PdfWinnovative().CreatePdfFile(url, fileName);
            ok.ShouldBeTrue();
        }
    }
}
