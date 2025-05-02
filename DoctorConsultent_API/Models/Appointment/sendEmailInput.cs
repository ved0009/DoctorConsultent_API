namespace DoctorConsultent_API.Models.Appointment
{
    public class sendEmailInput
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CustomerName { get; set; }
        public string ?InvoiceHtml { get; set; }
    }
}
