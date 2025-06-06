using Microsoft.AspNetCore.Mvc.ApiExplorer;
using PlataformaEducacaoOnline.API.Helpers;
using PlataformaEducacaoOnline.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder
    .AddAutenticacaoSettings()
    .AddApiSettings()
    .AddConteudoSettings()
    .AddAlunoSettings()
    .AddFinanceiroSettings()
    .AddSwaggerSettings();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseDbMigrationHelper();

app.Run();
