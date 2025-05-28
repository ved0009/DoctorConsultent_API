using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.IServices
{
    public interface IUserDetails
    {
        Task<IEnumerable<getPatientsListOutput>> getPatientsDetail();
        Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters);
        Task<List<getScheduleCallOutput>> getScheduleCallDetails(getScheduleCallInput InputParameters);
    }
}
