namespace DoctorConsultent_API.Models.Response
{
    public class Response
    {
     
            public bool? Result { get; set; }
            public string? Message { get; set; }
            public object? Data { get; set; }
            public int? ResponseCode { get; set; }
            public string? Severity { get; set; }
            public int? TotalRecords { get; set; }
            public int? TotalDisplayRecords { get; set; }
            public string? InnerException { get; set; }
            public string? StackTrace { get; set; }
      
    }
}
