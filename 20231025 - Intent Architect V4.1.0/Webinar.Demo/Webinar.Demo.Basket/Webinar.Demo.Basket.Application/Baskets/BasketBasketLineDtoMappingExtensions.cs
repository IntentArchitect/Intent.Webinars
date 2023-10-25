using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public static class BasketBasketLineDtoMappingExtensions
    {
        public static BasketBasketLineDto MapToBasketBasketLineDto(this BasketLine projectFrom, IMapper mapper)
            => mapper.Map<BasketBasketLineDto>(projectFrom);

        public static List<BasketBasketLineDto> MapToBasketBasketLineDtoList(this IEnumerable<BasketLine> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToBasketBasketLineDto(mapper)).ToList();
    }
}