using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Domain.Entities;
using Webinar.Demo.Basket.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Webinar.Demo.Basket.Application.Baskets.CreateBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Guid>
    {
        private readonly IBasketRepository _basketRepository;

        [IntentManaged(Mode.Merge)]
        public CreateBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var newBasket = new Domain.Entities.Basket
            {
                BasketLines = request.BasketLines.Select(CreateBasketLine).ToList(),
            };

            _basketRepository.Add(newBasket);
            await _basketRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newBasket.Id;
        }

        [IntentManaged(Mode.Fully)]
        private static BasketLine CreateBasketLine(CreateBasketBasketLineDto dto)
        {
            return new BasketLine
            {
                ProductId = dto.ProductId,
                Units = dto.Units,
                UnitPrice = dto.UnitPrice,
                Discount = dto.Discount,
            };
        }
    }
}