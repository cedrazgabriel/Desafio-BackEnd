using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RentalService.Application.Common.Interfaces;
using RentalService.Domain.Entities;
using RentalService.IntegrationEvents;
using System.Text.Json;

namespace RentalService.Infrastructure.Consumers;
public class MotorcycleRegisteredConsumer : BackgroundService
{
    private readonly ILogger<MotorcycleRegisteredConsumer> _logger;
    private readonly IAmazonSQS _sqs;
    private readonly INotificationEventRepository _repository;
    private readonly string _queueUrl;

    public MotorcycleRegisteredConsumer(
       ILogger<MotorcycleRegisteredConsumer> logger,
       IAmazonSQS sqs,
       IConfiguration config,
       INotificationEventRepository repository)
    {
        _logger = logger;
        _sqs = sqs;
        _repository = repository;
        _queueUrl = config["SQS:MotorcycleRegisteredQueueUrl"]!;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl,
                MaxNumberOfMessages = 5,
                WaitTimeSeconds = 5
            });

            foreach (var message in response.Messages)
            {
                try
                {
                    var evt = JsonSerializer.Deserialize<MotorcycleRegisteredEvent>(message.Body);

                    if (evt != null && evt.Year == 2024)
                    {
                        var notificacao = new NotificationEvent
                        {
                            EventType = "MotorcycleRegistered2024",
                            Data = message.Body,
                        };

                        await _repository.SaveAsync(notificacao);
                    }

                    await _sqs.DeleteMessageAsync(_queueUrl, message.ReceiptHandle);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar evento MotorcycleRegistered.");
                }
            }
        }
    }
}

