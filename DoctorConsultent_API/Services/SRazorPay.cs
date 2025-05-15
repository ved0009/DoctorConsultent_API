using DoctorConsultent_API.IServices;
using Razorpay.Api;
using Newtonsoft.Json;
using DoctorConsultent_API.Models.Appointment;

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

        public Task<string> GetPaymentDetails(string paymentId)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(_key, _secret);
                Payment payment = client.Payment.Fetch(paymentId);

                var paymentDetails = new Dictionary<string, object>
        {
            { "id", payment["id"] },
            { "method", payment["method"] },
            { "status", payment["status"] },
            { "bank", payment.Attributes.ContainsKey("bank") ? payment["bank"] : null },
            { "wallet", payment.Attributes.ContainsKey("wallet") ? payment["wallet"] : null },
            { "email", payment.Attributes.ContainsKey("email") ? payment["email"] : null },
            { "contact", payment.Attributes.ContainsKey("contact") ? payment["contact"] : null },
            { "amount", payment["amount"] },
            { "fee", payment.Attributes.ContainsKey("fee") ? payment["fee"] : null },
            { "tax", payment.Attributes.ContainsKey("tax") ? payment["tax"] : null },
            { "created_at", payment["created_at"] }
        };

                string json = JsonConvert.SerializeObject(paymentDetails); // Convert to JSON string
                return Task.FromResult(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching payment details: " + ex.Message);
            }
        }
    }
}
