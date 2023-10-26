using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>, ICommand
    {
        public CreateOrderCommand(Guid customerId, List<CreateOrderCommandBasketLinesDto> basketLines)
        {
            CustomerId = customerId;
            BasketLines = basketLines;
        }

        public Guid CustomerId { get; set; }
        public List<CreateOrderCommandBasketLinesDto> BasketLines { get; set; }
    }
}