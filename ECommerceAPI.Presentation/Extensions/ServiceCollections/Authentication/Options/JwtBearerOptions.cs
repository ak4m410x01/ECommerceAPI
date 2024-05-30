using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication.Options
{
    public static class JwtBearerOptions
    {
        public static AuthenticationBuilder AddJwtBearerOptions(this AuthenticationBuilder services, IConfiguration configuration)
        {
            services.AddJwtBearer(options =>
             {
                 options.RequireHttpsMetadata = false;
                 options.SaveToken = false;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidIssuer = configuration["JWT:Issuer"],
                     ValidAudience = configuration["JWT:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                     ClockSkew = TimeSpan.Zero
                 };
             });
            return services;
        }
    }
}
