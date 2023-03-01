using Mc2.CrudTest.Domain.Contracts.Common;
using Mc2.CrudTest.Shared.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Logics.Logics
{
    public class JWTAuthManagerLogic
    {
        private readonly IConfiguration _configuration;
        public JWTAuthManagerLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public MessageContract<string> GenerateJWT(UserContract user)
        {
            MessageContract<string> response = new MessageContract<string>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //claim is used to add identity to JWT token

            var token = new JwtSecurityToken(_configuration["JwtAuth:Issuer"],
              _configuration["JwtAuth:Issuer"],
              null,    //null original value
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            response.Result = new JwtSecurityTokenHandler().WriteToken(token); //return access token
            return response;
        }
        public MessageContract<bool> IsTokenValidation(TokenValidatiionContract tokenValidation)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;

                IPrincipal principal = tokenHandler.ValidateToken(tokenValidation.Token, validationParameters, out validatedToken);

                return new MessageContract<bool>()
                {
                    Result = true,
                    IsSucess = true
                };
            }
            catch (Exception ex)
            {

                return new MessageContract<bool>()
                {
                    Result = false,
                    IsSucess = false,
                    ErrorMessage = "Token not Valid please try again",
                    ErrorDetail = ex.Message
                };
            }

        }
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, 
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = _configuration["JwtAuth:Issuer"],
                ValidAudience = _configuration["JwtAuth:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"])) // The same key as the one that generate the token
            };
        }

    }
}
