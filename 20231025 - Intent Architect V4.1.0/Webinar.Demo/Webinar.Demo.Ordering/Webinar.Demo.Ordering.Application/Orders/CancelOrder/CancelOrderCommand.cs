using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders.CancelOrder
{
    public class CancelOrderCommand : IRequest, ICommand
    {
        public CancelOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}