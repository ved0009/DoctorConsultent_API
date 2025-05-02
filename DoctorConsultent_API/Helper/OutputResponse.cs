namespace DoctorConsultent_API.Helper
{
    public class OutputResponse
    {
        public static ResponseModel GenerateOutput(object response, string message, int totalRecords, int totalDisplayRecords)
        {
            var output = new ResponseModel()
            {
                Data = response,
                Result = true,
                Message = message,
                ResponseCode = 200,
                Severity = string.Empty,
                TotalRecords = totalRecords,
                TotalDisplayRecords = totalDisplayRecords,
                InnerException = null,
                StackTrace = string.Empty
            };

            return output;
        }
        public static ResponseModel ErrorGenerateOutput(object response, string message, int totalRecords, int totalDisplayRecords)
        {
            var output = new ResponseModel()
            {
                Data = response,
                Result = false,
                Message = message,
                ResponseCode = 200,
                Severity = string.Empty,
                TotalRecords = totalRecords,
                TotalDisplayRecords = totalDisplayRecords,
                InnerException = null,
                StackTrace = string.Empty
            };

            return output;
        }
    }
}
