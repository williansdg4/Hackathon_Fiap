using Microsoft.OpenApi.Models;
using Shared.Infrastructure.Authentication;
using System.Reflection;
using Shared.Infrastructure.Configurations;
using AppointmentScheduling.Domain.Configurations;
using AppointmentScheduling.Infrastructure.Configurations;
using Shared.Rabbit.Configurations;
using Shared.Rabbit.Infra;
using Shared.Infrastructure.Services;
using Shared.Infrastructure.Repositories;
using Shared.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthMedScheduling - Scheduling" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Token from authenticate",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        }, new List<string>()
    } });
});

builder.Services.ConfigurationRabbitProducer(options =>
{
    options.HostName = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.Host);
    options.Port = builder.Configuration.GetValue<int>(ApplicationVariables.Rabbit.Port);
    options.Username = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.User);
    options.Password = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.Password);
    options.VirtualHost = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.VirtualHost);
});


builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IRepository<Patient>, EFRepository<Patient>>();
builder.Services.DbConfiguration(configuration.GetConnectionString("HealthMedScheduling") ?? string.Empty);
builder.Services.AddJwtAuthentication();


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

app.Run();
