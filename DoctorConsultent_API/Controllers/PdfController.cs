using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using DoctorConsultent_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdf _invoiceService;

        public PdfController(IPdf invoiceService)
        {
            _invoiceService = invoiceService;
        }

        
    }
}
