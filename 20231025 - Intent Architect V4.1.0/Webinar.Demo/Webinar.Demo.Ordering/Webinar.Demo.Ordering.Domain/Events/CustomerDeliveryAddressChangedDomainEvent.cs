using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.DomainEvents.DomainEvent", Version = "1.0")]

namespace Webinar.Demo.Ordering.Domain.Events
{
    public class CustomerDeliveryAddressChangedDomainEvent : DomainEvent
    {
        public CustomerDeliveryAddressChangedDomainEvent(Guid customerId, Address address)
        {
            CustomerId = customerId;
            Address = address;
        }

        public Guid CustomerId { get; }
        public Address Address { get; }
    }
}