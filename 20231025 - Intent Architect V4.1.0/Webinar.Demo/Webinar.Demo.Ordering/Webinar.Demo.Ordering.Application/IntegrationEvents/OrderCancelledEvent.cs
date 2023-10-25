using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public record OrderCancelledEvent
    {
        public Guid OrderId { get; init; }
    }
}