using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public record OrderShippedEvent
    {
        public OrderShippedEvent()
        {
            DeliveryAddressLine1 = null!;
            DeliveryAddressLine2 = null!;
            DeliveryAddressCity = null!;
            DeliveryAddressPostal = null!;
        }

        public Guid OrderId { get; init; }
        public string DeliveryAddressLine1 { get; init; }
        public string DeliveryAddressLine2 { get; init; }
        public string DeliveryAddressCity { get; init; }
        public string DeliveryAddressPostal { get; init; }
    }
}