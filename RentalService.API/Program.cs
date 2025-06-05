using Amazon.SQS;
using RentalService.Application.Common.Interfaces;
using RentalService.Infrastructure.Consumers;
using RentalService.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

// Registro de serviços customizados
builder.Services.AddAWSService<IAmazonSQS>();
builder.Services.AddScoped<IEventPublisher, EventPublisher>();
builder.Services.AddHostedService<MotorcycleRegisteredConsumer>();

builder.Services.AddScoped<INotificationEventRepository, NotificationEventRepository>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
