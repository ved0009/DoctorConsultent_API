namespace DoctorConsultent_API.Models.Admin
{
    public class ConsultationDetailsInput
    {
        public int UserId { get; set; }
    }
    public class ConsultationDetailsOutput
    {

        public String Name { get; set; }
        public String Email { get; set; }
        public String MobileNumber { get; set; }
        public Int32? UserType { get; set; }
        public Int32 ID { get; set; }
        public Int32? UserID { get; set; }
        public String Symptom { get; set; }
        public Int32? Relevantspeciality { get; set; }
        public Int32? DoctorID { get; set; }
        public string? DoctorName { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String Status { get; set; }

}
}
