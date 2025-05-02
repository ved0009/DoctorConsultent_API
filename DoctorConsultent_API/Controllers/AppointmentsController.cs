using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IUserDetails _userDetails;
        public AppointmentsController(IUserDetails userDetails)
        {
            _userDetails = userDetails; 
        }
        [HttpGet("ping")]
        [AllowAnonymous]
        public IActionResult Ping()
        {
            return Ok("API is working!");
        }

        [HttpPost(nameof(insertUpduserDetails))]
        [AllowAnonymous]
        public async Task<IActionResult> insertUpduserDetails([FromBody()] insertUpduserDetailsInput inputParameters)
        {
            var obj = await _userDetails.insertUpduserDetails(inputParameters);
            if (obj == null)
            {
                List<object> list = new List<object>();
                IEnumerable<object> en = list;
                return NotFound(OutputResponse.GenerateOutput(en, "", 0, 0));
            }
            else
            {
                return Ok(OutputResponse.GenerateOutput(obj, "", 0, 0));
            }
        }

    }
}
