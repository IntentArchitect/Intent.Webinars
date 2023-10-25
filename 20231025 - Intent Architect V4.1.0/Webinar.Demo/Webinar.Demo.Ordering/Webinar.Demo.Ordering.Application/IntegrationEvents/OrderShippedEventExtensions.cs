using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Events;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public static class OrderShippedEventExtensions
    {
        public static OrderShippedEvent MapToOrderShippedEvent(this OrderShipedDomainEvent projectFrom)
        {
            return new OrderShippedEvent
            {
                OrderId = projectFrom.Order.Id,
                DeliveryAddressLine1 = projectFrom.Order.Customer.DeliveryAddress.Line1,
                DeliveryAddressLine2 = projectFrom.Order.Customer.DeliveryAddress.Line2,
                DeliveryAddressCity = projectFrom.Order.Customer.DeliveryAddress.City,
                DeliveryAddressPostal = projectFrom.Order.Customer.DeliveryAddress.Postal,
            };
        }
    }
}