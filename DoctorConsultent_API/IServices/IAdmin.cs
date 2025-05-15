using DoctorConsultent_API.Models.Admin;

namespace DoctorConsultent_API.IServices
{
    public interface IAdmin
    {
        Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters);
    }
}
