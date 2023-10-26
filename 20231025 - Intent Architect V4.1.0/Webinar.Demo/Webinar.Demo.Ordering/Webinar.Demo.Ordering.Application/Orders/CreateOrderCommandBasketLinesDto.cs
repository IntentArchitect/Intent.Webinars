using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders
{
    public class CreateOrderCommandBasketLinesDto
    {
        public CreateOrderCommandBasketLinesDto()
        {
        }

        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }

        public static CreateOrderCommandBasketLinesDto Create(Guid productId, int units, decimal unitPrice, decimal? discount)
        {
            return new CreateOrderCommandBasketLinesDto
            {
                ProductId = productId,
                Units = units,
                UnitPrice = unitPrice,
                Discount = discount
            };
        }
    }
}