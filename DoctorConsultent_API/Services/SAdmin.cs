using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Admin;

namespace DoctorConsultent_API.Services
{
    public class SAdmin : IAdmin
    {
        private readonly IAdminRepository _adminRepository;
        public SAdmin(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            
        }

        public async Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters)
        {
            return await _adminRepository.GetRevenueSummaryAsync(InputParameters);
        }
    }
}
