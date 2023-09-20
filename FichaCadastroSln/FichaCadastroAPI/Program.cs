using FichaCadastroAPI.HealthCheck;
using FichaCadastroAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=localhost;Database=FichaCadastro;Trusted_Connection=True;TrustServerCertificate=True;";

builder.Services
       .AddDbContext<FichaCadastroContextDB>(options => 
                                             options.UseSqlServer(connectionString));

//ConfigurationMapper
builder.Services.AddAutoMapper(typeof(Program));

//Configuração para deixar as rotas com letra minuscula
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;

});
//configurando appsettings
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//injeção dependencia healthcheck
string nomeHealthCheckCustom = nameof(HealthCheckCustom);
builder.Services
    .AddHealthChecks()
    .AddCheck<HealthCheckCustom>(nomeHealthCheckCustom);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
