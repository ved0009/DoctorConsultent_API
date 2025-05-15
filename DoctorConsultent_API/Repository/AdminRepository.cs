using Dapper;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.Models.Admin;
using SendGrid.Helpers.Mail;
using static Raven.Database.Server.Controllers.StreamsController.StreamQueryContent;

namespace DoctorConsultent_API.Repository
{
    public class AdminRepository :IAdminRepository
    {

        private readonly DapperContext _context;
        private const string USP_GETREVENUESUMMARYBYTYPE = "usp_GetRevenueSummaryByType";

        public AdminRepository(DapperContext dapperDBContext)
        {
            _context = dapperDBContext;
        }

        public async Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@type", InputParameters.Type);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<DashboardRevenueOutput>(USP_GETREVENUESUMMARYBYTYPE, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<DashboardRevenueOutput>();
            }
        }
    }
}
