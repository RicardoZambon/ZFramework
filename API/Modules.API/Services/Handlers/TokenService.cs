using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ZFramework.Modules.API.Services.Handlers
{
    public class TokenService : ITokenService
    {
        private readonly string ApiSecrets;

        public virtual DateTime TokenLifetime { get { return DateTime.UtcNow.AddHours(2); } }


        public TokenService(IOptions<TokenOptions> options)
        {
            ApiSecrets = options.Value.ApiSecrets;
        }


        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ApiSecrets);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimIdentity(username),
                Expires = TokenLifetime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        protected virtual ClaimsIdentity GetClaimIdentity(string username)
            => new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) });
    }
}