using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Eventing.Messages;
using Webinar.Demo.Ordering.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.MassTransit.IntegrationEventHandlerImplementation", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.IntegrationEventHandlers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CheckoutCompletedEventHandler : IIntegrationEventHandler<CheckoutCompletedEvent>
    {
        [IntentManaged(Mode.Merge)]
        public CheckoutCompletedEventHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task HandleAsync(CheckoutCompletedEvent message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}