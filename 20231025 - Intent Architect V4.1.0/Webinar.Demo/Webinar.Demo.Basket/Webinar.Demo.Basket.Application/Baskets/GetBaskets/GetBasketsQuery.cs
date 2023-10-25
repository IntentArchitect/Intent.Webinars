using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace Webinar.Demo.Basket.Application.Baskets.GetBaskets
{
    public class GetBasketsQuery : IRequest<List<BasketDto>>, IQuery
    {
        public GetBasketsQuery()
        {
        }
    }
}