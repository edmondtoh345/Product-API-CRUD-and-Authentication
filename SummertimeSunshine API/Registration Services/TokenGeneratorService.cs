using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SummertimeSunshine_API.Products_Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SummertimeSunshine_API.Registration_Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim("username", username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key_gayboy"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: "authapi",
              audience: "productapi",
              claims: claims,
              expires: System.DateTime.Now.AddMinutes(200),
              signingCredentials: creds
          );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(response);

        }
    }
}
