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
[assembly: IntentTemplate("Intent.MediatR.DomainEvents.DefaultDomainEventHandler", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.EventHandlers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class OrderShipedDomainEventHandler : INotificationHandler<DomainEventNotification<OrderShipedDomainEvent>>
    {
        private readonly IEventBus _eventBus;
        [IntentManaged(Mode.Merge)]
        public OrderShipedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(
            DomainEventNotification<OrderShipedDomainEvent> notification,
            CancellationToken cancellationToken)
        {
            var integrationEvent = notification.DomainEvent.MapToOrderShippedEvent();
            _eventBus.Publish(integrationEvent);
        }
    }
}