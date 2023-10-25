using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Events;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public static class OrderCancelledEventExtensions
    {
        public static OrderCancelledEvent MapToOrderCancelledEvent(this OrderCancelledDomainEvent projectFrom)
        {
            return new OrderCancelledEvent
            {
                OrderId = projectFrom.Order.Id,
            };
        }
    }
}