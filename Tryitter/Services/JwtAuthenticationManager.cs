using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tryitter.Services
{
    public class JwtAuthenticationManager
    {
        public JwtAuthResponse Authenticate(string email)
        {

            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(Constants.Constants.JWT_TOKEN_VALIDITY_MINS);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Constants.Constants.JWT_SECURITY_KEY);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("Email", email),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new JwtAuthResponse
            {
                Token = token,
                Email = email,
            };
        }
    }
}
