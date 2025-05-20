namespace DoctorConsultent_API.Models.Admin
{
    public class DashboardWrapperInput
    {
        
            public int UserType { get; set; }      
            public string UserName { get; set; }

    }
   
    public class DashboardWrapperOutput
    {
        public string dashboardLabel { get; set; }
        public int dashboardCount { get; set; }
      

    }
}
