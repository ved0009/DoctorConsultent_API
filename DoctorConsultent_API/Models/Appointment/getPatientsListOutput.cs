namespace DoctorConsultent_API.Models.Appointment
{
     
    public class getPatientsListOutput
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Symptom { get; set; }
        public string AssignedDoctor { get; set; }
        public string Status { get; set; }         
        public string PaymentStatus { get; set; }    
    }
}
