using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Admin;
using DoctorConsultent_API.Models.Appointment;
using DoctorConsultent_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;


        }

        [HttpGet(nameof(GetGlobalData))]        
        public async Task<IActionResult> GetGlobalData()
        {
            var obj = await _admin.GetGlobalData();
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
     
        
        [HttpGet(nameof(PatientsLists))]
        public async Task<IActionResult> PatientsLists()
        {
            var obj = await _admin.PatientsLists();
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

        [HttpGet(nameof(GetDoctorsList))]
        public async Task<IActionResult> GetDoctorsList()
        {
            var obj = await _admin.GetDoctorsList();
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


        [HttpPost(nameof(GetRevenueSummary))]
        public async Task<IActionResult> GetRevenueSummary([FromQuery] DashboardRevenueInput InputParameters)
        {
            var result = await _admin.GetRevenueSummaryAsync(InputParameters);
            var response = new
            {
                labels = result.Select(x => x.Label).ToList(),
                data = result.Select(x => x.TotalRevenue).ToList()
            };
            return Ok(response);
        }

        [HttpPost(nameof(GetDashboardWrapper))]
        public async Task<IActionResult> GetDashboardWrapper([FromBody()] DashboardWrapperInput inputParameters)
        {
            var obj = await _admin.GetDashboardWrapper(inputParameters);
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


        [HttpPost(nameof(GetPaymentDetails))]
        public async Task<IActionResult> GetPaymentDetails([FromBody()] PaymentDetilsInput inputParameters)
        {
            var obj = await _admin.GetPaymentDetails(inputParameters);
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

        [HttpPost(nameof(GetConsultationList))]
        public async Task<IActionResult> GetConsultationList([FromBody()] ConsultationDetailsInput inputParameters)
        {
            var obj = await _admin.GetConsultationList(inputParameters);
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

        [HttpPost(nameof(UpdateConsultationStatus))]
        public async Task<IActionResult> UpdateConsultationStatus([FromBody()] UpdateConsultationStatusInput inputParameters)
        {
            var obj = await _admin.UpdateConsultationStatus(inputParameters);
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

        [HttpPost(nameof(InsertAppointedDoctorandTime))]
        public async Task<IActionResult> InsertAppointedDoctorandTime([FromBody()] InsertAppointedDoctorandTimeInput inputParameters)
        {
            var obj = await _admin.InsertAppointedDoctorandTime(inputParameters);
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

        [HttpPost(nameof(GetPatientsHistory))]
        public async Task<IActionResult> GetPatientsHistory([FromBody()] PatientHistoryInput inputParameters)
        {
            var obj = await _admin.GetPatientsHistory(inputParameters);
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

        [HttpPost(nameof(UpdateGlobalVariableName))]
        public async Task<IActionResult> UpdateGlobalVariableName([FromBody()] UpdateGlobalvariableValueInput inputParameters)
        {
            var obj = await _admin.UpdateGlobalVariableName(inputParameters);
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
