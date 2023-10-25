using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders.AddOrderLineOrder
{
    public class AddOrderLineOrderCommand : IRequest, ICommand
    {
        public AddOrderLineOrderCommand(Guid id, Guid productId, int units, decimal unitPrice, decimal? discount)
        {
            Id = id;
            ProductId = productId;
            Units = units;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
    }
}