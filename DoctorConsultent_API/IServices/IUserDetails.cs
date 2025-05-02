using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.IServices
{
    public interface IUserDetails
    {
        Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters); 
    }
}
