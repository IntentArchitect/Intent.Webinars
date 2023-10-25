using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public static class BasketDtoMappingExtensions
    {
        public static BasketDto MapToBasketDto(this Domain.Entities.Basket projectFrom, IMapper mapper)
            => mapper.Map<BasketDto>(projectFrom);

        public static List<BasketDto> MapToBasketDtoList(this IEnumerable<Domain.Entities.Basket> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToBasketDto(mapper)).ToList();
    }
}