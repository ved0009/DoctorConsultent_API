namespace DoctorConsultent_API.Models.Appointment
{
    public class getScheduleCallOutput
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string MobileNumber { get; set; }
            public string RelevantSpeciality { get; set; }
            public string Symptom { get; set; }
            public string DoctorName { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
       

    }
}
