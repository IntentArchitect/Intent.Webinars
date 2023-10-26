using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Eventing.Messages;
using Webinar.Demo.Ordering.Application.Common.Eventing;
using Webinar.Demo.Ordering.Application.Orders;
using Webinar.Demo.Ordering.Application.Orders.CreateOrder;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.MassTransit.IntegrationEventHandler", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.IntegrationEvents.EventHandlers.Orders
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class CheckoutCompletedEventHandler : IIntegrationEventHandler<CheckoutCompletedEvent>
    {
        private readonly ISender _mediator;

        [IntentManaged(Mode.Merge)]
        public CheckoutCompletedEventHandler(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task HandleAsync(CheckoutCompletedEvent message, CancellationToken cancellationToken = default)
        {
            var command = new CreateOrderCommand(message.Id, message.BasketLines
                .Select(bl => new CreateOrderCommandBasketLinesDto
                {
                    ProductId = bl.ProductId,
                    Units = bl.Units,
                    UnitPrice = bl.UnitPrice,
                    Discount = bl.Discount
                })
                .ToList());

            await _mediator.Send(command, cancellationToken);
        }
    }
}