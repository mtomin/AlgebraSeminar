using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Models
{
    public class AuthorizeJWT : AuthorizeAttribute
    {
        private static readonly string secret = ConfigurationManager.AppSettings["JWTsecret"];
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["auth_token"] == null)
            {
                return false;
            }

            string token = httpContext.Request.Cookies["auth_token"].Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false, // Because there is no audience in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token

                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(secret))
            };

            return tokenValidationParameters;
        }
    }
}