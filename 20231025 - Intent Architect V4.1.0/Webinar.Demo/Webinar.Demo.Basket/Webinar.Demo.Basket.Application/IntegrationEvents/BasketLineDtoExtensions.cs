using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.DtoExtensions", Version = "1.0")]

namespace Webinar.Demo.Basket.Eventing.Messages
{
    public static class BasketLineDtoExtensions
    {
        public static BasketLineDto MapToBasketLineDto(this BasketLine projectFrom)
        {
            return new BasketLineDto
            {
                Id = projectFrom.Id,
                ProductId = projectFrom.ProductId,
                Units = projectFrom.Units,
                UnitPrice = projectFrom.UnitPrice,
                Discount = projectFrom.Discount,
                BasketId = projectFrom.BasketId,
            };
        }
    }
}