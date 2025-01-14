using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NutriBase.Logic.Contracts;
using NutriBase.Logic.Models.Accounts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NutriBase.Logic.Services
{
    public class TokenService(IConfiguration config) : ServiceObject, ITokenService
    {
        public string CreateToken(UserDto user)
        {
            if(user.Username == null) 
                throw new ArgumentNullException(nameof(user.Username));

            var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenkey from appsettings");
            if (tokenKey.Length < 64) throw new Exception("Applied tokenKey is not long enough");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            

            return tokenHandler.WriteToken(token);
        }
    }
}
