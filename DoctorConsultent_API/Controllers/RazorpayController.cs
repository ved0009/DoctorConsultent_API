using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazorpayController : ControllerBase
    {
        private readonly IRazorPay _razorpayServices;
        public RazorpayController(IRazorPay razorpayServices)
        {

            _razorpayServices = razorpayServices;
        }


        [HttpPost("MakePayment")]
        public async Task<IActionResult> CreateOrder([FromBody] int amount)
        {
            string orderId = await _razorpayServices.CreateOrder(amount); // Expect a string

            if (string.IsNullOrEmpty(orderId))
            {
                return Ok(OutputResponse.GenerateOutput(new List<object>(), "Order creation failed", 0, 0));
            }
            else
            {
                return Ok(OutputResponse.GenerateOutput(orderId, "Order created successfully", 0, 0));
            }
        }
    }
}
