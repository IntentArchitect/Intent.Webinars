using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders.ShipOrder
{
    public class ShipOrderCommand : IRequest, ICommand
    {
        public ShipOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}