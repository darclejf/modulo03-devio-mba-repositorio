using MediatR;
using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Conteudos.Application.Commands;
using PlataformaEducacaoOnline.Conteudos.Application.Queries;
using PlataformaEducacaoOnline.Conteudos.Data;
using PlataformaEducacaoOnline.Conteudos.Data.Repository;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;

namespace PlataformaEducacaoOnline.API.Settings
{
    public static class ConteudoSettings
    {
        public static WebApplicationBuilder AddConteudoSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ConteudoDbContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            builder.Services.AddScoped<ICursoQueries, CursoQueries>();

            builder.Services.AddScoped<IRequestHandler<AdicionarCursoCommand, bool>, CursoCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<AdicionarAulaCursoCommand, bool>, CursoCommandHandler>();

            return builder;
        }
    }
}
