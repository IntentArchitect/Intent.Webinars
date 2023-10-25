using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public record ProductCreatedEvent
    {
        public ProductCreatedEvent()
        {
            Name = null!;
            Description = null!;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}