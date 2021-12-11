using bibliotecaAPI.Services.Auth.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace bibliotecaAPI.Configuration
{
    public static class AuthConfiguracaoExtensions
    {
        public static void AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfigurations = configuration.GetSection("JwtConfigurations").Get<JwtConfigurations>();
            var key = Encoding.ASCII.GetBytes(jwtConfigurations.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfigurations.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = jwtConfigurations.Audience,
                    ValidateAudience = true
                };
            });
        }
    }
}
