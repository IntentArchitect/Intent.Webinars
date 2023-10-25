using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets.UpdateBasket
{
    public class UpdateBasketCommand : IRequest, ICommand
    {
        public UpdateBasketCommand(Guid id, List<UpdateBasketBasketLineDto> basketLines)
        {
            Id = id;
            BasketLines = basketLines;
        }

        public Guid Id { get; set; }
        public List<UpdateBasketBasketLineDto> BasketLines { get; set; }
    }
}