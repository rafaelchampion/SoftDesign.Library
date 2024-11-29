using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SoftDesign.Library.Services
{
    public class JwtService
    {
        private static readonly string SecretKey = "8k}:0QP1ml&0-4r+fOn!1UHiSt6k@B&qW;6-wG]17oM76d6]?9";
        private static readonly byte[] SecretKeyBytes = Convert.FromBase64String(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(SecretKey)));

        public static string GenerateToken(string username, string role, int expireMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(SecretKeyBytes);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(SecretKeyBytes);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateLifetime = true
            };

            return tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        }
    }
}
