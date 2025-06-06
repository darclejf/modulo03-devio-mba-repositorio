using MediatR;
using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Alunos.Data;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;
using PlataformaEducacaoOnline.Alunos.Data.Repository;
using PlataformaEducacaoOnline.Alunos.Application.Commands;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;
using PlataformaEducacaoOnline.Alunos.Application.Events;
using PlataformaEducacaoOnline.Alunos.Application.Queries;

namespace PlataformaEducacaoOnline.API.Settings
{
    public static class AlunoSettings
    {
        public static WebApplicationBuilder AddAlunoSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AlunoDbContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
            builder.Services.AddScoped<IAlunoQuery, AlunoQuery>();

            builder.Services.AddScoped<IRequestHandler<NovoAlunoCommand, bool>, AlunoCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<IniciarMatriculaCommand, bool>, AlunoCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<IniciarAulaCommand, bool>, AlunoCommandHandler>();

            builder.Services.AddScoped<INotificationHandler<UsuarioCriadoIntegrationEvent>, AlunoEventHandler>();
            builder.Services.AddScoped<INotificationHandler<PagamentoRealizadoEvent>, AlunoEventHandler>();
            builder.Services.AddScoped<INotificationHandler<PagamentoRecusadoEvent>, AlunoEventHandler>();

            return builder;
        }
    }
}
