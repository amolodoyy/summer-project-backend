using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using wiki.business.Domains;
using wiki.data;

namespace wiki.business
{
    public class TokenManager
    {
        public static string GenerateToken(Users user)
        {
            List<Claim> claimsIdentity = new List<Claim>();
            claimsIdentity.Add(new Claim(ClaimTypes.Name, user.Email));
            claimsIdentity.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;

        }



    }

}
