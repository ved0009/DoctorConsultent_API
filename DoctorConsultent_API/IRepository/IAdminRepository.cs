using DoctorConsultent_API.Models.Admin;

namespace DoctorConsultent_API.IRepository
{
    public interface IAdminRepository
    {
        Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters);
    }
}
