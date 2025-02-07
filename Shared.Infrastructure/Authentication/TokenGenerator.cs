using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shared.Infrastructure.Authentication
{
    public interface ITokenGenerator
    {
        string Generate(IdentityUser user);        
    }

    public class TokenGenerator : ITokenGenerator
    {
        readonly UserManager<IdentityUser> _userManager;

        public TokenGenerator(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string Generate(IdentityUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Role, roles?.FirstOrDefault()),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.Name, user.UserName),
                }),

                Issuer = TokenGenerationKey.Issuer,
                Audience = TokenGenerationKey.Audience,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenGenerationKey.Key)), SecurityAlgorithms.HmacSha256Signature)
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }
    }
}
