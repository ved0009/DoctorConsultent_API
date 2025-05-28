using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using static Raven.Database.Server.Controllers.StreamsController.StreamQueryContent;

namespace DoctorConsultent_API.Services
{
    public class SUserDetails : IUserDetails
    {
        private readonly IUserDetailsRepository _userDetailsrepositpry;
        private readonly IConfiguration _configuration;
        public SUserDetails(IUserDetailsRepository userDetailsrepositpry, IConfiguration configuration)
        {
            _userDetailsrepositpry = userDetailsrepositpry;
            _configuration = configuration;
        }

        public async Task<IEnumerable<getPatientsListOutput>> getPatientsDetail()
        {
            return await _userDetailsrepositpry.getPatientsDetail();
        }

        public async Task<List<getScheduleCallOutput>> getScheduleCallDetails(getScheduleCallInput InputParameters)
        {
            return await _userDetailsrepositpry.getScheduleCallDetails(InputParameters);
        }

        public async Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters)
        {
            return await _userDetailsrepositpry.insertUpduserDetails(inputParameters);
        }
    }
}
