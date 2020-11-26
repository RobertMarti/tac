using System.IO;
using Winnovative;

namespace tac.Pdf.PdfLibrary
{
    public class PdfWinnovative
    {
        public bool CreatePdfFile(string url, string fileName)
        {
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og=";

            // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
            htmlToPdfConverter.HtmlViewerWidth = 1024;

            // Set HTML viewer height in pixels to convert the top part of a HTML page 
            // Leave it not set to convert the entire HTML
            //htmlToPdfConverter.HtmlViewerHeight = 800;

            // Set PDF page size which can be a predefined size like A4 or a custom size in points 
            // Leave it not set to have a default A4 PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;

            // Set PDF page orientation to Portrait or Landscape
            // Leave it not set to have a default Portrait orientation for PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;

            // Set the maximum time in seconds to wait for HTML page to be loaded 
            // Leave it not set for a default 60 seconds maximum wait time
            htmlToPdfConverter.NavigationTimeout = 30;

            // Set an adddional delay in seconds to wait for JavaScript or AJAX calls after page load completed
            // Set this property to 0 if you don't need to wait for such asynchcronous operations to finish
            //htmlToPdfConverter.ConversionDelay = int.Parse(conversionDelayTextBox.Text);

            var fullFileName = Path.Combine(@"C:\Temp\Pdf\PdfWinnovative", fileName);

            htmlToPdfConverter.ConvertUrlToFile(url, fullFileName);

            return File.Exists(fullFileName);
        }
    }
}