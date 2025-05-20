using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;

using DoctorConsultent_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Raven.Database.FileSystem.Storage.Voron.Impl.Tables;

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
        public IActionResult Ping()
        {
            return Ok("API is working!");
        }

        [HttpPost(nameof(insertUpduserDetails))]
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

        [HttpGet(nameof(getPatientsDetail))]
        public async Task<IActionResult> getPatientsDetail()
        {
            var obj = await _userDetails.getPatientsDetail();
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
