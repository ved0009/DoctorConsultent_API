namespace DoctorConsultent_API.IServices
{
    public interface IRazorPay
    {
        Task<string> CreateOrder(int amount);
    }
}
