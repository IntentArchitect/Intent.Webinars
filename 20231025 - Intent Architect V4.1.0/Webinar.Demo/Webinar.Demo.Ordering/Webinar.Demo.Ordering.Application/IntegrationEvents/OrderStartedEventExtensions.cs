using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public static class OrderStartedEventExtensions
    {
        public static OrderStartedEvent MapToOrderStartedEvent(this Order projectFrom)
        {
            return new OrderStartedEvent
            {
                Id = projectFrom.Id,
                OrderDate = projectFrom.OrderDate,
                CustomerId = projectFrom.CustomerId,
            };
        }
    }
}