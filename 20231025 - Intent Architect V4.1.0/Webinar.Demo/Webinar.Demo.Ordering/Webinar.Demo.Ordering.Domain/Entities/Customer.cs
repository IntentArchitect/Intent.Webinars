using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Common;
using Webinar.Demo.Ordering.Domain.Events;

namespace Webinar.Demo.Ordering.Domain.Entities
{
    public class Customer : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Address? BillingAddress { get; set; }

        public Address DeliveryAddress { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void ChangeDeliveryAddress(Address address)
        {
            DomainEvents.Add(new CustomerDeliveryAddressChangedDomainEvent(Id, address));
        }
    }
}