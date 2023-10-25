using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets.DeleteBasket
{
    public class DeleteBasketCommand : IRequest, ICommand
    {
        public DeleteBasketCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}