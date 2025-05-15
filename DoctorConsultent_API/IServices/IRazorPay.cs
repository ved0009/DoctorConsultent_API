using DoctorConsultent_API.Models.Appointment;


namespace DoctorConsultent_API.IServices
{
    public interface IRazorPay
    {
        Task<string> CreateOrder(int amount);
        Task<string> GetPaymentDetails(string paymentId);
    }
}
