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
        public class PaymentRequestDto
        {
            public string PaymentId { get; set; }
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
        [HttpPost("GetDetails")]
        public async Task<IActionResult> GetPaymentDetails([FromBody] string paymentId)
        {
            string paymentDetailsJson = await _razorpayServices.GetPaymentDetails(paymentId); // Get details as JSON string

            if (string.IsNullOrEmpty(paymentDetailsJson))
            {
                return Ok(OutputResponse.GenerateOutput(new List<object>(), "Failed to fetch payment details", 0, 0));
            }
            else
            {
                return Ok(OutputResponse.GenerateOutput(paymentDetailsJson, "Payment details fetched successfully", 0, 0));
            }
        }

    }
}
