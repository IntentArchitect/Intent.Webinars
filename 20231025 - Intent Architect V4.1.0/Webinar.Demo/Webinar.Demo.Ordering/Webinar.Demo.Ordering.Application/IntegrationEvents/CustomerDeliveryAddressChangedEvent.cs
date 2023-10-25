using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public record CustomerDeliveryAddressChangedEvent
    {
        public CustomerDeliveryAddressChangedEvent()
        {
            AddressLine1 = null!;
            AddressLine2 = null!;
            AddressCity = null!;
            AddressPostal = null!;
        }

        public Guid CustomerId { get; init; }
        public string AddressLine1 { get; init; }
        public string AddressLine2 { get; init; }
        public string AddressCity { get; init; }
        public string AddressPostal { get; init; }
    }
}