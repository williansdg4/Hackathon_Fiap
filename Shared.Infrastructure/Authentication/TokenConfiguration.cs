using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Enums;
using System.Text;

namespace Shared.Infrastructure.Authentication
{
    public static class TokenConfiguration
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters.ValidateIssuer = true;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.ValidIssuer = TokenGenerationKey.Issuer;
                    options.TokenValidationParameters.ValidAudience = TokenGenerationKey.Audience;
                    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenGenerationKey.Key));
                });

            return services;
        }
    }
}
