using DoctorConsultent_API.Models.Admin;

namespace DoctorConsultent_API.IServices
{
    public interface IAdmin
    {
        Task<List<DashboardRevenueOutput>> GetRevenueSummaryAsync(DashboardRevenueInput InputParameters);
        Task<List<DashboardWrapperOutput>> GetDashboardWrapper(DashboardWrapperInput InputParameters);
        Task<List<PaymentDetilsOutput>> GetPaymentDetails(PaymentDetilsInput InputParameters);
        Task<List<ConsultationDetailsOutput>> GetConsultationList(ConsultationDetailsInput InputParameters);
        Task<List<PatientHistoryOutput>> GetPatientsHistory(PatientHistoryInput InputParameters);
        Task<List<GlobalDataOutput>> GetGlobalData();
        Task<List<getPatientsListsOutput>> PatientsLists();
        Task<List<int>> UpdateGlobalVariableName(UpdateGlobalvariableValueInput InputParameters);

        Task<List<int>> UpdateConsultationStatus(UpdateConsultationStatusInput InputParameters);
        Task<List<int>> InsertAppointedDoctorandTime(InsertAppointedDoctorandTimeInput  InputParameters);
        Task<List<getAllMasterOutput>> GetDoctorsList();





    }
}
