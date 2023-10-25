using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Domain.Common;
using Webinar.Demo.Basket.Domain.Common.Exceptions;
using Webinar.Demo.Basket.Domain.Entities;
using Webinar.Demo.Basket.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Webinar.Demo.Basket.Application.Baskets.UpdateBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;

        [IntentManaged(Mode.Merge)]
        public UpdateBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var existingBasket = await _basketRepository.FindByIdAsync(request.Id, cancellationToken);
            if (existingBasket is null)
            {
                throw new NotFoundException($"Could not find Basket '{request.Id}'");
            }

            existingBasket.BasketLines = UpdateHelper.CreateOrUpdateCollection(existingBasket.BasketLines, request.BasketLines, (e, d) => e.Id == d.Id, CreateOrUpdateBasketLine);
        }

        [IntentManaged(Mode.Fully)]
        private static BasketLine CreateOrUpdateBasketLine(BasketLine entity, UpdateBasketBasketLineDto dto)
        {
            entity ??= new BasketLine();
            entity.ProductId = dto.ProductId;
            entity.Units = dto.Units;
            entity.UnitPrice = dto.UnitPrice;
            entity.Discount = dto.Discount;
            entity.BasketId = dto.BasketId;

            return entity;
        }
    }
}