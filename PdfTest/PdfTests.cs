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

        [Test]
        [TestCase(UrlEiger, FileEiger)]
        [TestCase(UrlPost, FilePost)]
        [TestCase(UrlWertsachen, FileWertsachen)]

        public void PdfExpert(string url, string fileName)
        {
            var ok = new PdfCreatorExpert().CreatePdfFile(url, fileName);
            ok.ShouldBeTrue();
        }
    }
}
