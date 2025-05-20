using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Admin;
using static Raven.Database.Server.Controllers.StreamsController.StreamQueryContent;

namespace DoctorConsultent_API.Services
{
    public class SAdmin : IAdmin
    {
        private readonly IAdminRepository _adminRepository;
        public SAdmin(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            
        }

        public async Task<List<ConsultationDetailsOutput>> GetConsultationList(ConsultationDetailsInput InputParameters)
        {
            return await _adminRepository.GetConsultationList(InputParameters);
        }

        public async Task<List<DashboardWrapperOutput>> GetDashboardWrapper(DashboardWrapperInput InputParameters)
        {
            return await _adminRepository.GetDashboardWrapper(InputParameters);
        }

        public async Task<List<getAllMasterOutput>> GetDoctorsList()
        {
            return await _adminRepository.GetDoctorsList();
        }

        public async Task<List<GlobalDataOutput>> GetGlobalData()
        {
            return await _adminRepository.GetGlobalData();
        }

        public async Task<List<PatientHistoryOutput>> GetPatientsHistory(PatientHistoryInput InputParameters)
        {
            return await _adminRepository.GetPatientsHistory(InputParameters);
        }

        public async Task<List<PaymentDetilsOutput>> GetPaymentDetails(PaymentDetilsInput InputParameters)
        {
            return await _adminRepository.GetPaymentDetails(InputParameters);
        }

        public async Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters)
        {
            return await _adminRepository.GetRevenueSummaryAsync(InputParameters);
        }

        public async Task<List<int>> InsertAppointedDoctorandTime(InsertAppointedDoctorandTimeInput InputParameters)
        {
            return await _adminRepository.InsertAppointedDoctorandTime(InputParameters);
        }

        public async Task<List<getPatientsListsOutput>> PatientsLists()
        {
            return await _adminRepository.PatientsLists();
        }

        public async Task<List<int>> UpdateConsultationStatus(UpdateConsultationStatusInput InputParameters)
        {
            return await _adminRepository.UpdateConsultationStatus(InputParameters);
        }

        public async Task<List<int>> UpdateGlobalVariableName(UpdateGlobalvariableValueInput InputParameters)
        {
            return await _adminRepository.UpdateGlobalVariableName(InputParameters);
        }
    }
}
