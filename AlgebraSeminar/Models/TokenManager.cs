using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AlgebraSeminar.Models
{
    public class TokenManager
    {
        private static readonly string secret = ConfigurationManager.AppSettings["JWTsecret"];

        public static string GenerateToken(Zaposlenik trenutniZaposlenik)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, trenutniZaposlenik.KorisnickoIme),
                new Claim(ClaimTypes.GivenName, String.Format("{0} {1}", trenutniZaposlenik.Ime, trenutniZaposlenik.Prezime))
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}