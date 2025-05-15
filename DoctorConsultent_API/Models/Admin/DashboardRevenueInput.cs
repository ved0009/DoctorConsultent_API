namespace DoctorConsultent_API.Models.Admin
{
    public class DashboardRevenueOutput
    {
      
            public string Label { get; set; }       // e.g., "21 Aug 2024" / "Week 18 (2024)"
            public decimal TotalRevenue { get; set; }

    }
    public class DashboardRevenueInput
    {

        public string Type { get; set; }       // e.g., "21 Aug 2024" / "Week 18 (2024)"
        

    }
}
