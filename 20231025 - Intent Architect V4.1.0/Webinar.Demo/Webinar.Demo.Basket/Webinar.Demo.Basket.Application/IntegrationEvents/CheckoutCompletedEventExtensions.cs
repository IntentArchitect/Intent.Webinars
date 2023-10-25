using System.Linq;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Basket.Eventing.Messages
{
    public static class CheckoutCompletedEventExtensions
    {
        public static CheckoutCompletedEvent MapToCheckoutCompletedEvent(this Domain.Entities.Basket projectFrom)
        {
            return new CheckoutCompletedEvent
            {
                Id = projectFrom.Id,
                BasketLines = projectFrom.BasketLines.Select(BasketLineDtoExtensions.MapToBasketLineDto).ToList(),
            };
        }
    }
}