using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets.CreateBasket
{
    public class CreateBasketCommand : IRequest<Guid>, ICommand
    {
        public CreateBasketCommand(List<CreateBasketBasketLineDto> basketLines)
        {
            BasketLines = basketLines;
        }

        public List<CreateBasketBasketLineDto> BasketLines { get; set; }
    }
}