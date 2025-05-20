using Razorpay.Api;
using System.Transactions;
using System;
using static Raven.Database.Indexing.IndexingWorkStats;

namespace DoctorConsultent_API.Models.Admin
{
    public class PaymentDetilsInput
    {
        public string? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
 
    }

    public class PaymentDetilsOutput
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionTime { get; set; }

    }
}
