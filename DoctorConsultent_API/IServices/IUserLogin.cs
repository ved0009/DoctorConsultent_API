using DoctorConsultent_API.Models.Appointment;
using DoctorConsultent_API.Models.Auth;

namespace DoctorConsultent_API.IServices
{
    public interface IUserLogin
    {
        Task<IEnumerable<string>> getUserLogin(userLoginInput inputParameters);
    }
}
