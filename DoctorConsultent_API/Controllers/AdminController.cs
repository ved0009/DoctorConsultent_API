using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Admin;
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
    }
}
