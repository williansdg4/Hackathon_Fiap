using Shared.Rabbit.Configurations;
using Shared.Infrastructure.Configurations;
using Shared.Rabbit.Infra;
using AppointmentConsumer.Worker.Configurations;

var builder = Host.CreateApplicationBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddRabbitMq(options =>
{
    options.HostName = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.Host);
    options.Port = builder.Configuration.GetValue<int>(ApplicationVariables.Rabbit.Port);
    options.Username = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.User);
    options.Password = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.Password);
    options.VirtualHost = builder.Configuration.GetValue<string>(ApplicationVariables.Rabbit.VirtualHost);
});

builder.Services.AddPatientQueue(builder.Configuration);
builder.Services.AddDoctorQueue(builder.Configuration);
builder.Services.AddAppointmentQueue(builder.Configuration);
builder.Services.AddTimeScheduleQueue(builder.Configuration);
builder.Services.DbConfiguration(configuration.GetConnectionString("HealthMedScheduling") ?? string.Empty);

var host = builder.Build();
host.Run();
