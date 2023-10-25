using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public record OrderStartedEvent
    {
        public Guid Id { get; init; }
        public DateTime OrderDate { get; init; }
        public Guid CustomerId { get; init; }
    }
}