using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Events;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public static class CustomerDeliveryAddressChangedEventExtensions
    {
        public static CustomerDeliveryAddressChangedEvent MapToCustomerDeliveryAddressChangedEvent(this CustomerDeliveryAddressChangedDomainEvent projectFrom)
        {
            return new CustomerDeliveryAddressChangedEvent
            {
                CustomerId = projectFrom.CustomerId,
                AddressLine1 = projectFrom.Address.Line1,
                AddressLine2 = projectFrom.Address.Line2,
                AddressCity = projectFrom.Address.City,
                AddressPostal = projectFrom.Address.Postal,
            };
        }
    }
}