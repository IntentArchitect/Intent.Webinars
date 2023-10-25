using System;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Application.Common.Mappings;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public class BasketBasketLineDto : IMapFrom<BasketLine>
    {
        public BasketBasketLineDto()
        {
        }

        public Guid ProductId { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public Guid BasketId { get; set; }
        public Guid Id { get; set; }

        public static BasketBasketLineDto Create(
            Guid productId,
            int units,
            decimal unitPrice,
            decimal? discount,
            Guid basketId,
            Guid id)
        {
            return new BasketBasketLineDto
            {
                ProductId = productId,
                Units = units,
                UnitPrice = unitPrice,
                Discount = discount,
                BasketId = basketId,
                Id = id
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketLine, BasketBasketLineDto>();
        }
    }
}