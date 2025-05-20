using Razorpay.Api;

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
        public Decimal? Amount { get; set; }
        public String PaymentMethod { get; set; }
        public String TransactionStatus { get; set; }
        public String PaymentId { get; set; }
        public String Bank { get; set; }
        public Decimal TransactionFee { get; set; }
        public Decimal TransactionTax { get; set; }
        


    }


}
