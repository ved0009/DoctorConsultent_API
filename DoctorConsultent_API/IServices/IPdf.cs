using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.IServices
{
    public interface IPdf
    {
        Task<bool> SendEmailAsync(sendEmailInput request);
    }
}
