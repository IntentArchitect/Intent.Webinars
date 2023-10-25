using System;
using System.Collections.Generic;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Application.Common.Mappings;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets
{
    public class BasketDto : IMapFrom<Domain.Entities.Basket>
    {
        public BasketDto()
        {
            BasketLines = null!;
        }

        public Guid Id { get; set; }
        public List<BasketBasketLineDto> BasketLines { get; set; }

        public static BasketDto Create(Guid id, List<BasketBasketLineDto> basketLines)
        {
            return new BasketDto
            {
                Id = id,
                BasketLines = basketLines
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Basket, BasketDto>()
                .ForMember(d => d.BasketLines, opt => opt.MapFrom(src => src.BasketLines));
        }
    }
}