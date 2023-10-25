using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Common;
using Webinar.Demo.Ordering.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.DomainEvents.DomainEvent", Version = "1.0")]

namespace Webinar.Demo.Ordering.Domain.Events
{
    public class OrderCreatedDomainEvent : DomainEvent
    {
        public OrderCreatedDomainEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}