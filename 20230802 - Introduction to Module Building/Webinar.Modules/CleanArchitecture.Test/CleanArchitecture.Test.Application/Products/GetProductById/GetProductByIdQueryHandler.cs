using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Test.Domain.Common.Exceptions;
using CleanArchitecture.Test.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CleanArchitecture.Test.Application.Products.GetProductById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(request.Id, cancellationToken);
            if (product is null)
            {
                throw new NotFoundException($"Could not find Product '{request.Id}'");
            }

            return product.MapToProductDto(_mapper);
        }
    }
}