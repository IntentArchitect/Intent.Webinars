using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public class CreateBasketBasketLineDto
    {
        public CreateBasketBasketLineDto()
        {
        }

        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }

        public static CreateBasketBasketLineDto Create(Guid productId, int units, decimal unitPrice, decimal? discount)
        {
            return new CreateBasketBasketLineDto
            {
                ProductId = productId,
                Units = units,
                UnitPrice = unitPrice,
                Discount = discount
            };
        }
    }
}