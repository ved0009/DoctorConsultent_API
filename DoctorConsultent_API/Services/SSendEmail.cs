using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using System.Net.Mail;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace DoctorConsultent_API.Services
{
    public class SSendEmail : ISendEmail
    {
        private readonly IConfiguration _configuration;
        private readonly IConverter _pdfConverter;

        public SSendEmail(IConfiguration configuration, IConverter pdfConverter)
        {
            _configuration = configuration;
            _pdfConverter = pdfConverter;
        }

        public async Task<bool> SendEmailAsync(sendEmailInput request)
        {
            try
            {
                string smtpClient = _configuration["EmailSettings:smtpClient"];
                string smtpUserName = _configuration["EmailSettings:smtpUserName"];
                string smtpPassword = _configuration["EmailSettings:smtpPassword"];
                int smtpPort = int.Parse(_configuration["EmailSettings:smtpPort"]);
                bool enableSSL = bool.Parse(_configuration["EmailSettings:enableSSL"]);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(smtpUserName);
                    mail.To.Add(request.To);
                    if (!string.IsNullOrWhiteSpace(request.Cc))
                    {
                        mail.CC.Add(request.Cc);
                    }
                    mail.Subject = GetSubject(request.CustomerName);
                    mail.Body = GetThankYouEmail(request.CustomerName);
                    mail.IsBodyHtml = true;

                    // Generate PDF
                    var htmlToPdf = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                        Objects = {
                    new ObjectSettings() {
                        HtmlContent = request.InvoiceHtml
                    }
                }
                    };
                    byte[] pdfBytes = _pdfConverter.Convert(htmlToPdf);

                    // Attach PDF
                    mail.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), "Invoice.pdf"));

                    using (SmtpClient smtp = new SmtpClient(smtpClient, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                        smtp.EnableSsl = enableSSL;
                        await smtp.SendMailAsync(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

        private string GetSubject(string customerName)
        {
            return $@"Hi {customerName}, Thanks for Reaching Out! We'll Connect You Shortly";
        }
        private string GetThankYouEmail(string customerName)
        {
            return $@"<!DOCTYPE html>
            <html>
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                <title>Thank You for Contacting Us</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #e0e0e0; /* Light grey background */
                        margin: 0;
                        padding: 0;
                        display: flex;
                        justify-content: center;
                        align-items: center;
                        min-height: 100vh;
                    }}
                    .container {{
                        max-width: 600px;
                        background: linear-gradient(145deg, #ffffff, #f8f8f8);
                        margin: 20px auto;
                        padding: 20px;
                        border-radius: 12px;
                        box-shadow: 5px 5px 15px rgba(0, 0, 0, 0.2), -5px -5px 15px rgba(255, 255, 255, 0.5);
                        text-align: center;
                    }}
                    .header {{
                        background: linear-gradient(135deg, #3399cc, #2a87b3);
                        padding: 20px;
                        border-radius: 12px 12px 0 0;
                    }}
                    .header h1 {{
                        color: #ffffff;
                        margin: 0;
                        font-size: 24px;
                    }}
                    .content {{
                        padding: 20px;
                        font-size: 16px;
                        color: #444;
                        line-height: 1.6;
                    }}
                    .footer {{
                        background: #f4f4f4;
                        padding: 15px;
                        font-size: 14px;
                        color: #666;
                        border-radius: 0 0 12px 12px;
                        box-shadow: inset 2px 2px 8px rgba(0, 0, 0, 0.1);
                    }}
                    .footer a {{
                        color: #3399cc;
                        text-decoration: none;
                        font-weight: bold;
                    }}
                    .cta-button {{
                        display: inline-block;
                        background: linear-gradient(135deg, #3399cc, #2a87b3);
                        color: #ffffff;
                        text-decoration: none;
                        padding: 12px 20px;
                        border-radius: 8px;
                        font-size: 16px;
                        margin-top: 20px;
                        font-weight: bold;
                        box-shadow: 3px 3px 8px rgba(0, 0, 0, 0.2);
                        transition: all 0.3s ease-in-out;
                    }}
                    .cta-button:hover {{
                        background: #23729a;
                        box-shadow: none;
                    }}
                    .svg-image {{
                        width: 80px;
                        margin-bottom: 15px;
                    }}
                    /* Responsive Design */
                    @media screen and (max-width: 600px) {{
                        .container {{
                            width: 90%;
                            padding: 15px;
                        }}
                        .content {{
                            font-size: 14px;
                            padding: 15px;
                        }}
                        .cta-button {{
                            width: 80%;
                            padding: 10px;
                        }}
                    }}
                </style>
            </head>
            <body>

                <div class=""container"">
                    <!-- Header -->
                    <div class=""header"">
                        <!-- SVG Illustration -->
                        <img src=""https://cdn-icons-png.flaticon.com/512/845/845646.png"" class=""svg-image"" alt=""Thank You"">
                        <h1>Thank You for Reaching Out!</h1>
                    </div>

                    <div class=""content"">
                        <p>Dear {customerName},</p>
                        <p>Thank you for updating your consultation request.</p>
                        <p>Our doctor will review your request and contact you shortly to assist you further.</p>
                        <p>If you have any further queries, feel free to visit our 
                            <a href=""#"" style=""color: #3399cc; font-weight: bold; text-decoration: none;"">Help Center</a>.
                        </p>

                        <a href=""#"" class=""cta-button"">Visit Help Center</a>
                    </div>

                    <div class=""footer"">
                        <p><strong>Please do not reply</strong> to this email. This is an automated message.</p>
                        <p>&copy; 2024 Your Company Name. All Rights Reserved.</p>
                    </div>
                </div>

            </body>
            </html>
            ";

        }
    }
}
