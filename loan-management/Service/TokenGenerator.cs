using LoanManagement.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoanManagement.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateJSONWebToken(User user)
        {

            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.Name)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisloanmanagementapitokengeneratedbyjwt"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"APILoanManagementApp",
              audience:"LoanManagementUsers",
              claims: userClaims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return JsonConvert.SerializeObject(new { Token = jwtSecurityTokenHandler, Name = user.Name, Email = user.Email });
        }
    }
}
