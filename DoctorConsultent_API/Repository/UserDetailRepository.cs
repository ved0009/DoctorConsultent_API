using Dapper;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.Models.Appointment;
using static Raven.Database.Server.Controllers.StreamsController.StreamQueryContent;

namespace DoctorConsultent_API.Repository
{
    public class UserDetailRepository : IUserDetailsRepository
    {
        private readonly DapperContext _context;
        private const string SP_INSERTUPDUSERDETAIL = "sp_insertUpdUserDetail";
        private const string USP_GETUSERSFORCONSULTATION = "usp_GetUsersForConsultation";
        private const string USP_GETSCHEDULECALLDETAILS = "usp_getScheduleCallDetails";




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
                proc_parameters.Add("@Amount", inputParameters.Amount);
                proc_parameters.Add("@PaymentMethod", inputParameters.PaymentMethod);
                proc_parameters.Add("@TransStatus", inputParameters.TransactionStatus);
                proc_parameters.Add("@PaymentId", inputParameters.PaymentId);
                proc_parameters.Add("@Bank", inputParameters.Bank);
                proc_parameters.Add("@TransactionFee", inputParameters.TransactionFee);
                proc_parameters.Add("@TransactionTax", inputParameters.TransactionTax);





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

        public async Task<IEnumerable<getPatientsListOutput>> getPatientsDetail()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<getPatientsListOutput>(USP_GETUSERSFORCONSULTATION, null, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<getPatientsListOutput>();
            }
        }

        public async Task<List<getScheduleCallOutput>> getScheduleCallDetails(getScheduleCallInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@MobileNo", InputParameters.MobileNo);
                
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<getScheduleCallOutput>(USP_GETSCHEDULECALLDETAILS, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<getScheduleCallOutput>();
            }
        }
    }
}
