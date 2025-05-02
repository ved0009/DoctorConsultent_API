using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using DoctorConsultent_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmail _sendEmail;
        private readonly SPdfService _pdfService;

        public SendEmailController(ISendEmail sendEmail, SPdfService pdfService)
        {
            _sendEmail = sendEmail;
            _pdfService = pdfService;
        }
        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] sendEmailInput request)
        {
            bool isSent = await _sendEmail.SendEmailAsync(request);

            if (isSent)
            {
                return Ok(new { message = "Email sent successfully!" });
            }
            return BadRequest(new { message = "Failed to send email." });
        }

    

      
    }
}
