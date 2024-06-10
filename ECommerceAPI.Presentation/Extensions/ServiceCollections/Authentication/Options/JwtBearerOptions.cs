using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

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

                 options.Events = new JwtBearerEvents
                 {
                     OnChallenge = context =>
                     {
                         context.HandleResponse();
                         context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                         context.Response.ContentType = "application/json";
                         var result = JsonSerializer.Serialize(new { error = "Token is not provided or invalid." });
                         return context.Response.WriteAsync(result);
                     }
                 };
             });

            return services;
        }
    }
}