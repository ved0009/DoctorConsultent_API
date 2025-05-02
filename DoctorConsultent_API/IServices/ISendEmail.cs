using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.IServices
{
    public interface ISendEmail
    {
        Task<bool> SendEmailAsync(sendEmailInput request);
    }
}
