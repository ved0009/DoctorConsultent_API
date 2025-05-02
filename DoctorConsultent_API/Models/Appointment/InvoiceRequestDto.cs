namespace DoctorConsultent_API.Models.Appointment
{
    public class InvoiceRequestDto
    {
       public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string PlaceOfSupply { get; set; }
            public string HSNCode { get; set; }
            public string TaxPointDate { get; set; }
            public string Description { get; set; }
            public decimal NetAmount { get; set; }
            public decimal IGST { get; set; }
            public decimal GrossAmount { get; set; }
            public string QRCodeUrl { get; set; }
            public string CompanyLogoUrl { get; set; }
        

    }
}
