using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;

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

        public async Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters)
        {
            return await _userDetailsrepositpry.insertUpduserDetails(inputParameters);
        }
    }
}
