using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlataformaEducacaoOnline.Autenticacao.Data;
using PlataformaEducacaoOnline.Autenticacao.Interfaces;
using PlataformaEducacaoOnline.Autenticacao.Models;
using PlataformaEducacaoOnline.Autenticacao.Services;
using System.Text;

namespace PlataformaEducacaoOnline.API.Settings
{
    public static class AutenticacaoSettings
    {
        public static WebApplicationBuilder AddAutenticacaoSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AutenticacaoDbContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
           

            builder.Services
                .AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AutenticacaoDbContext>();
                //.AddErrorDescriber<MensagensIdentityPortugues>();


            var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettingsModel>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettingsModel>();
            var key = Encoding.ASCII.GetBytes(jwtSettings?.Secret!);

            builder.Services.
                AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtSettings?.Issuer,
                        ValidAudience = jwtSettings?.Audience
                    };
                });

            builder.Services.AddScoped<IAutenticacaoServices, AutenticacaoServices>(serviceProvider => 
                                                    new AutenticacaoServices(
                                                        serviceProvider.GetRequiredService<SignInManager<IdentityUser<Guid>>>(),
                                                        serviceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>(),
                                                        jwtSettings
                                                    ));
            return builder;
        }
    }
}
