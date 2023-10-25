using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets.GetBasketById
{
    public class GetBasketByIdQuery : IRequest<BasketDto>, IQuery
    {
        public GetBasketByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}