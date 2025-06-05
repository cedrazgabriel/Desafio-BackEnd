using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using RentalService.Application.Common.Interfaces;
using RentalService.Domain.Entities;
using RentalService.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RentalService.Infrastructure.Messaging;
public class EventPublisher : IEventPublisher
{
    private readonly IAmazonSQS _sqs;
    private readonly string _queueUrl;

    public EventPublisher(IAmazonSQS sqs, IConfiguration configuration)
    {
        _sqs = sqs;
        _queueUrl = configuration["SQS:MotorcycleRegisteredQueueUrl"]!;
    }

    public async Task PublishRegisteredMotorcycle(Moto moto)
    {
        var message = new MotorcycleRegisteredEvent
        {
            Id = moto.Id,
            Model = moto.Model,
            Year = moto.Year,
            LicensePlate = moto.LicensePlate.Value
        };

        var sendRequest = new SendMessageRequest
        {
            QueueUrl = _queueUrl,
            MessageBody = JsonSerializer.Serialize(message)
        };

        await _sqs.SendMessageAsync(sendRequest);
    }
}
