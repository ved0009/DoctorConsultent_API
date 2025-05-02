namespace DoctorConsultent_API.Models.Appointment
{
    public class insertUpduserDetailsInput
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String MobileNumber { get; set; }
        public Int32? UserType { get; set; }
        public String Symptom { get; set; }

    }
}
