using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace Webinar.Demo.Basket.Eventing.Messages
{
    public record CheckoutCompletedEvent
    {
        public CheckoutCompletedEvent()
        {
            BasketLines = null!;
        }

        public Guid Id { get; init; }
        public List<BasketLineDto> BasketLines { get; init; }
    }
}