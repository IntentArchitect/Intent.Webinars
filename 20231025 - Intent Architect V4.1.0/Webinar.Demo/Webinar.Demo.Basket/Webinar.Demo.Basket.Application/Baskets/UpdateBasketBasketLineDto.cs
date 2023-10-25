using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public class UpdateBasketBasketLineDto
    {
        public UpdateBasketBasketLineDto()
        {
        }

        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public Guid BasketId { get; set; }
        public Guid Id { get; set; }

        public static UpdateBasketBasketLineDto Create(
            Guid productId,
            int units,
            decimal unitPrice,
            decimal? discount,
            Guid basketId,
            Guid id)
        {
            return new UpdateBasketBasketLineDto
            {
                ProductId = productId,
                Units = units,
                UnitPrice = unitPrice,
                Discount = discount,
                BasketId = basketId,
                Id = id
            };
        }
    }
}