using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventDto", Version = "1.0")]

namespace Webinar.Demo.Basket.Eventing.Messages
{
    public class BasketLineDto
    {
        public BasketLineDto()
        {
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public Guid BasketId { get; set; }

        public static BasketLineDto Create(Guid id, Guid productId, int units, decimal unitPrice, decimal? discount, Guid basketId)
        {
            return new BasketLineDto
            {
                Id = id,
                ProductId = productId,
                Units = units,
                UnitPrice = unitPrice,
                Discount = discount,
                BasketId = basketId
            };
        }
    }
}