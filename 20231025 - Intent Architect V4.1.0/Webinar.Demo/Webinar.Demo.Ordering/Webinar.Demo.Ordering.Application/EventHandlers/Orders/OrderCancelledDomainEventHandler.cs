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

namespace Webinar.Demo.Ordering.Application.EventHandlers.Orders
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class OrderCancelledDomainEventHandler : INotificationHandler<DomainEventNotification<OrderCancelledDomainEvent>>
    {
        private readonly IEventBus _eventBus;

        [IntentManaged(Mode.Merge)]
        public OrderCancelledDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task Handle(
            DomainEventNotification<OrderCancelledDomainEvent> notification,
            CancellationToken cancellationToken)
        {
            _eventBus.Publish(new OrderCancelledEvent
            {
                OrderId = notification.DomainEvent.Order.Id
            });
        }
    }
}