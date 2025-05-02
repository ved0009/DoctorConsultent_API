using Dapper;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.Models.Appointment;

namespace DoctorConsultent_API.Repository
{
    public class UserDetailRepository : IUserDetailsRepository
    {
        private readonly DapperContext _context;
        private const string SP_INSERTUPDUSERDETAIL = "sp_insertUpdUserDetail";


        public UserDetailRepository(DapperContext dapperDBContext)
        {
            _context = dapperDBContext;
        }


        public async Task<IEnumerable<int>> insertUpduserDetails(insertUpduserDetailsInput inputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@ID", inputParameters.ID); 
                proc_parameters.Add("@Name", inputParameters.Name); 
                proc_parameters.Add("@Email", inputParameters.Email); 
                proc_parameters.Add("@MobileNumber", inputParameters.MobileNumber);
                proc_parameters.Add("@UserType", inputParameters.UserType);
                proc_parameters.Add("@Symptom", inputParameters.Symptom);



                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<int>(SP_INSERTUPDUSERDETAIL, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<int>();
            }
           
        }
    }
}
