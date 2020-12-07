using System.IO;
using NetworkProxyType = ExpertPdf.HtmlToPdf.NetworkProxyType;
using PdfCompressionLevel = ExpertPdf.HtmlToPdf.PdfCompressionLevel;
using PdfConverter = ExpertPdf.HtmlToPdf.PdfConverter;
using PdfPageSize = ExpertPdf.HtmlToPdf.PdfPageSize;

namespace tac.Pdf.PdfLibrary
{
    public class PdfCreatorExpert
    {

        private const string DestinationPath = @"C:\Temp\Pdf\Expert";

        public bool CreatePdfFile(string url, string fileName)
        {
            PdfConverter pdfConverter = new PdfConverter();

            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            pdfConverter.PdfDocumentOptions.LeftMargin = 5;
            pdfConverter.PdfDocumentOptions.RightMargin = 5;
            pdfConverter.PdfDocumentOptions.TopMargin = 5;
            pdfConverter.PdfDocumentOptions.BottomMargin = 5;
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;

            pdfConverter.PdfDocumentOptions.ShowHeader = false;

            //pdfConverter.ProxyOptions.Type = NetworkProxyType.Http;

            //// Set proxy hostname and port number
            //// Hostname and port number are required when the proxy type is set to something different from None value
            //pdfConverter.ProxyOptions.HostName = "outproxy1.pnet.ch";
            //pdfConverter.ProxyOptions.PortNumber = 3128;

            //pdfConverter.LicenseKey = "3Pfu/OT87evu/OXy7Pzv7fLt7vLl5eXl";
            var fullFileName = Path.Combine(DestinationPath, fileName);
            pdfConverter.SavePdfFromUrlToFile(url, fullFileName);

            return File.Exists(fullFileName);
        }
    }
}
