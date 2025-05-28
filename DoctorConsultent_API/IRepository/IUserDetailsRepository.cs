using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.IRepository
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<getPatientsListOutput>> getPatientsDetail();
        Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters);
        Task<List<getScheduleCallOutput>> getScheduleCallDetails(getScheduleCallInput InputParameters);

    }
}
