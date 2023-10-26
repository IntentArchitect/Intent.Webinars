using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Eventing;
using Webinar.Demo.Ordering.Application.Common.Models;
using Webinar.Demo.Ordering.Domain.Events;
using Webinar.Demo.Ordering.Eventing.Messages;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MediatR.DomainEvents.DomainEventHandler", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.EventHandlers.Customers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CustomerDeliveryAddressChangedDomainEventHandler : INotificationHandler<DomainEventNotification<CustomerDeliveryAddressChangedDomainEvent>>
    {
        private readonly IEventBus _eventBus;

        [IntentManaged(Mode.Merge)]
        public CustomerDeliveryAddressChangedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task Handle(
            DomainEventNotification<CustomerDeliveryAddressChangedDomainEvent> notification,
            CancellationToken cancellationToken)
        {
            _eventBus.Publish(new CustomerDeliveryAddressChangedEvent
            {
                CustomerId = notification.DomainEvent.CustomerId,
                AddressLine1 = notification.DomainEvent.Address.Line1,
                AddressLine2 = notification.DomainEvent.Address.Line2,
                AddressCity = notification.DomainEvent.Address.City,
                AddressPostal = notification.DomainEvent.Address.Postal
            });
        }
    }
}