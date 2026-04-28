using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Contact_Management_Service.Models;

namespace Contact_Management_Service.Services
{
    public class JwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
              _config = config;
        }
        public string GenerateJSONWebToken(User userObj)
        {
            var key = _config["Jwt:Key"];
            Console.WriteLine(key);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            SigningCredentials credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);

            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userObj.UserName)),
                new Claim(ClaimTypes.Name, userObj.UserName),
                new Claim(ClaimTypes.Role, userObj.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // (JWT ID) Claim
            };


            JwtSecurityToken token = new JwtSecurityToken(
                            issuer: "YourIssuer",
                            audience: "YourAudience",
                            claims: authClaims,
                            expires: DateTime.Now.AddHours(2),
                            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(token);    // Generate JWT Token string 

            return tokenString;
        }
    }
}