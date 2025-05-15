namespace DoctorConsultent_API.Models.Auth
{
    public class userLoginInput
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
    }
    public class UserLoginOutput
    {
        public string Token { get; set; }
        public IEnumerable<string> UserData { get; set; }  
    }
}
