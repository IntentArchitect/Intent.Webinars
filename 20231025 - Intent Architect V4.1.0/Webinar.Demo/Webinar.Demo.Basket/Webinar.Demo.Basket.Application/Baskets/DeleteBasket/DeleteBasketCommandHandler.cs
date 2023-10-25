using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Basket.Domain.Common.Exceptions;
using Webinar.Demo.Basket.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Webinar.Demo.Basket.Application.Baskets.DeleteBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;

        [IntentManaged(Mode.Merge)]
        public DeleteBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var existingBasket = await _basketRepository.FindByIdAsync(request.Id, cancellationToken);
            if (existingBasket is null)
            {
                throw new NotFoundException($"Could not find Basket '{request.Id}'");
            }

            _basketRepository.Remove(existingBasket);
        }
    }
}