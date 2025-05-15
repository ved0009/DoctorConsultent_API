using Dapper;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Auth;

namespace DoctorConsultent_API.Services
{
    public class SUserLogin : IUserLogin
    {
        private readonly DapperContext _context;
        private const string USP_CHECKADMINCREDENTIALS = "usp_CheckAdminCredentials";


        public SUserLogin(DapperContext dapperDBContext)
        {
            _context = dapperDBContext;
        }

        public async Task<IEnumerable<string>> getUserLogin(userLoginInput inputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@UserName", inputParameters.UserName);
                proc_parameters.Add("@Password", inputParameters.Password);
              
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<string>(USP_CHECKADMINCREDENTIALS, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<string>();
            }


        }
    }
}
