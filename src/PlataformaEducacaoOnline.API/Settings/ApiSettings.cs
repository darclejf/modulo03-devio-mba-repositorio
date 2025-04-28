using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages.Notifications;
using System.Reflection;

namespace PlataformaEducacaoOnline.API.Settings
{
    public static class ApiConfiguration
    {
        public static WebApplicationBuilder AddApiSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods("GET")
                            .WithOrigins("http://desenvolvedor.io")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });

            // Mediator
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>(serviceProvider => new MediatorHandler(serviceProvider.GetRequiredService<IMediator>()));

            // Notifications
            builder.Services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            return builder;
        }
    }
}
