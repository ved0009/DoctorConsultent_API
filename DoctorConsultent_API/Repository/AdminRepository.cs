using Dapper;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.Models.Admin;
using DoctorConsultent_API.Models.Appointment;
using SendGrid.Helpers.Mail;
using static Raven.Database.Server.Controllers.StreamsController.StreamQueryContent;

namespace DoctorConsultent_API.Repository
{
    public class AdminRepository :IAdminRepository
    {
        
        private readonly DapperContext _context;
        private const string USP_GETREVENUESUMMARYBYTYPE = "usp_GetRevenueSummaryByType";
        private const string USP_UPDATEGLOBALCONFIGVALUE = "usp_updateGlobalConfigValue";
        private const string USP_GETDASHBOARDWRAPPER = "usp_getDashboardWrapper";
        private const string USP_GETPAYMENTDETAILS = "usp_getPaymentDetails";
        private const string USP_GETCONSULTATIONLIST = "usp_getConsultationList";
        private const string USP_GETGLOBALDATA = "usp_getGlobalData";
        private const string USP_GETPATIENTSLISTS = "usp_getPatientsLists";
        private const string USP_GETPATIENTSHISTORY = "usp_getPatientsHistory";

        private const string USP_UPDATECONSULTATIONSTATUS = "usp_updateConsultationStatus";
        private const string USP_INSERTAPPOINTEDDOCTORANDTIME = "usp_InsertAppointedDoctorandTime";
        private const string USP_GETDOCTORSLIST = "usp_getDoctorsList";




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

        public async Task<List<DashboardWrapperOutput>> GetDashboardWrapper(DashboardWrapperInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@UserType", InputParameters.UserType);
                proc_parameters.Add("@UserName", InputParameters.UserName);
              
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<DashboardWrapperOutput>(USP_GETDASHBOARDWRAPPER, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<DashboardWrapperOutput>();
            }
        }

        public async Task<List<PaymentDetilsOutput>> GetPaymentDetails(PaymentDetilsInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@Status", InputParameters.Status);
                proc_parameters.Add("@FromDate", InputParameters.FromDate);
                proc_parameters.Add("@ToDate", InputParameters.ToDate);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<PaymentDetilsOutput>(USP_GETPAYMENTDETAILS, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<PaymentDetilsOutput>();
            }
        }

        public async Task<List<ConsultationDetailsOutput>> GetConsultationList(ConsultationDetailsInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@UserId", InputParameters.UserId);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<ConsultationDetailsOutput>(USP_GETCONSULTATIONLIST, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<ConsultationDetailsOutput>();
            }
        }

        public async Task<List<GlobalDataOutput>> GetGlobalData()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<GlobalDataOutput>(USP_GETGLOBALDATA, null, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<GlobalDataOutput>();
            }
        }

        public async Task<List<int>> UpdateGlobalVariableName(UpdateGlobalvariableValueInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@ID", InputParameters.ID);
                proc_parameters.Add("@GlobalVariableValue", InputParameters.GlobalVariableValue);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<int>(USP_UPDATEGLOBALCONFIGVALUE, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<int>();
            }
        }

        public async Task<List<getPatientsListsOutput>> PatientsLists()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<getPatientsListsOutput>(USP_GETPATIENTSLISTS, null, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<getPatientsListsOutput>();
            }
        }

        public async Task<List<PatientHistoryOutput>> GetPatientsHistory(PatientHistoryInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@UserId", InputParameters.ID);       
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<PatientHistoryOutput>(USP_GETPATIENTSHISTORY, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<PatientHistoryOutput>();
            }
        }

        public async Task<List<int>> UpdateConsultationStatus(UpdateConsultationStatusInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@ConID", InputParameters.ConID);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<int>(USP_UPDATECONSULTATIONSTATUS, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<int>();
            }
        }

        public async Task<List<int>> InsertAppointedDoctorandTime(InsertAppointedDoctorandTimeInput InputParameters)
        {
            try
            {

                var proc_parameters = new DynamicParameters();
                proc_parameters.Add("@ConID", InputParameters.ConID);
                proc_parameters.Add("@UserId", InputParameters.UserID);
                proc_parameters.Add("@Relevantspeciality", InputParameters.RelevantSpeciality);
                proc_parameters.Add("@DoctorID", InputParameters.DoctorID);
                proc_parameters.Add("@StartTime", InputParameters.StartTime);
                proc_parameters.Add("@EndTime", InputParameters.EndTime);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<int>(USP_INSERTAPPOINTEDDOCTORANDTIME, proc_parameters, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<int>();
            }
        }

        public async Task<List<getAllMasterOutput>> GetDoctorsList()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<getAllMasterOutput>(USP_GETDOCTORSLIST, null, null, Constants.TIMEOUT, System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<getAllMasterOutput>();
            }
        }
    }
}
