using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Services
{
    public class TokenService : ITokenService
    {
        //_key is a secret key that is used to generate the token
        private readonly SymmetricSecurityKey _key;
        //_userManager
        private readonly UserManager<User> _userManager;

        public TokenService(IConfiguration config, UserManager<User> userManager)
        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        public async Task<string> GenerateToken(User user)
        {
            //Create a list of claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            //Get roles of the user
            var roles = await _userManager.GetRolesAsync(user);

            //Add roles to the claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //Create credentials
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Create a token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            //Create a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //Create a token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
