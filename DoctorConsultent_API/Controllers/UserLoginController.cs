using DoctorConsultent_API.Helper;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using DoctorConsultent_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoctorConsultent_API.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using static Raven.Client.Linq.LinqPathProvider;

namespace DoctorConsultent_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserLogin _userLogin;

        public UserLoginController(IUserLogin userLogin, IConfiguration configuration)
        {
            _userLogin = userLogin;
            _configuration = configuration;
        }

        [HttpPost(nameof(getUserLogin))]
        [AllowAnonymous]
        public async Task<IActionResult> getUserLogin([FromBody()] userLoginInput inputParameters)
        {
            var obj = await _userLogin.getUserLogin(inputParameters);
            if (obj == null|| obj.FirstOrDefault() == "Invalid")
            {
                List<object> list = new List<object>();
                IEnumerable<object> en = list;
                return Unauthorized(OutputResponse.GenerateOutput(en, "Invalid username or password.", 0, 0));
            }
            else
            {
                 
                    var token = GenerateJwtToken(inputParameters.UserName);
                    var response = new UserLoginOutput
                    {
                        Token = token,
                        UserData = obj
                    };

                    return Ok(OutputResponse.GenerateOutput(response, "Login successful", 1, 0));
                 
            }
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "userId"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
            issuer: jwtSettings["ValidIssuer"],
            audience: jwtSettings["ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireTime"])),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

        
 }
