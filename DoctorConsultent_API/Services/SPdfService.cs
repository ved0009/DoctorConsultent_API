using DoctorConsultent_API.IServices;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.TeamFoundation.WorkItemTracking;
using SendGrid.Helpers.Mail.Model;
using System.IO;

namespace DoctorConsultent_API.Services
{
    public class SPdfService  
    {
        public byte[] GeneratePdfFromHtml(string htmlContent)
        {
                using (MemoryStream stream = new MemoryStream())
                {
                    // Create PdfWriter with the stream as the output
                    PdfWriter writer = new PdfWriter(stream);

                    // Create PdfDocument which will write the output to the PdfWriter
                    PdfDocument pdfDocument = new PdfDocument(writer);

                    // Use HtmlConverter to convert the HTML string to PDF
                    HtmlConverter.ConvertToPdf(htmlContent, pdfDocument);

                    // Return the PDF content as byte array
                    return stream.ToArray();
                }
            
        }

    }
}
