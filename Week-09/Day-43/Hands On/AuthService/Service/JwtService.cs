using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Service
{
    public class JwtService
    {
        public string GenerateJSONWebToken(User userObj)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_IMPORTANT_KEY_ASKJFALKDJF57454897454"));

            SigningCredentials credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);

            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userObj.UserName)),
                new Claim(ClaimTypes.Name, userObj.Email),
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
