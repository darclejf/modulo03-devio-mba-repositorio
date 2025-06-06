using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Financeiro.AntiCorruption;
using PlataformaEducacaoOnline.Financeiro.Business.Interfaces;
using PlataformaEducacaoOnline.Financeiro.Business.Services;
using PlataformaEducacaoOnline.Financeiro.Data;
using PlataformaEducacaoOnline.Financeiro.Data.Repository;

namespace PlataformaEducacaoOnline.API.Settings
{
    public static class FinanceiroSettings
    {
        public static WebApplicationBuilder AddFinanceiroSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<FinanceiroDBContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            builder.Services.AddScoped<IPagamentoService, PagamentoService>();
            builder.Services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            builder.Services.AddScoped<IPayPalGateway, PayPalGateway>();
            builder.Services.AddScoped<PlataformaEducacaoOnline.Financeiro.AntiCorruption.IConfigurationManager, PlataformaEducacaoOnline.Financeiro.AntiCorruption.ConfigurationManager>();

            return builder;
        }
    }
}
