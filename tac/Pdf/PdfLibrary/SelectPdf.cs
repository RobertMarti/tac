using System.IO;
using SelectPdf;

namespace tac.Pdf.PdfLibrary
{
    public class SelectPdf
    {
        public bool CreatePdfFile(string url, string fileName, int width)
        {
            var pageSize = PdfPageSize.A4;
            var pdfOrientation = PdfPageOrientation.Portrait;
            var webPageWidth = width;
            var webPageHeight = 0;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            var fullFileName = Path.Combine(@"C:\Temp\Pdf\SelectPdf", fileName);
            doc.Save(fullFileName);

            // close pdf document
            doc.Close();

            return File.Exists(fullFileName);
        }
    }
}