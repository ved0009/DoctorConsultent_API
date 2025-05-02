using DoctorConsultent_API.IServices;
using Razorpay.Api;

namespace DoctorConsultent_API.Services
{
    public class SRazorPay : IRazorPay
    {
        private readonly string _key;
        private readonly string _secret;
        public SRazorPay(IConfiguration configuration)
        {
            _key = configuration["Razorpay:Key"];
            _secret = configuration["Razorpay:Secret"];
        }

        public async Task<string> CreateOrder(int amount)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(_key, _secret);

                Dictionary<string, object> options = new Dictionary<string, object>
        {
            { "amount", amount * 100 },  // Convert to paisa
            { "currency", "INR" },
            { "receipt", "order_rcptid_11" },
            { "payment_capture", 1 }
        };

                Order order = await Task.Run(() => client.Order.Create(options)); // Ensure async execution
                return order["id"].ToString(); // Return Order ID as string
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating order: " + ex.Message);
            }
        }
    }
}
