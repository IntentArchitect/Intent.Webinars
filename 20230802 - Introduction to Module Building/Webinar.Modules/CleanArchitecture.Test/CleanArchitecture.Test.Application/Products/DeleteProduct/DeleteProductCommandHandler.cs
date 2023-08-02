using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Test.Domain.Common.Exceptions;
using CleanArchitecture.Test.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace CleanArchitecture.Test.Application.Products.DeleteProduct
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        [IntentManaged(Mode.Merge)]
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.FindByIdAsync(request.Id, cancellationToken);
            if (existingProduct is null)
            {
                throw new NotFoundException($"Could not find Product '{request.Id}'");
            }

            _productRepository.Remove(existingProduct);
        }
    }
}