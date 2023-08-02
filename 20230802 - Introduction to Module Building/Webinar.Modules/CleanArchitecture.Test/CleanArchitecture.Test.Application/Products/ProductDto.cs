using System;
using AutoMapper;
using CleanArchitecture.Test.Application.Common.Mappings;
using CleanArchitecture.Test.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CleanArchitecture.Test.Application.Products
{
    public class ProductDto : IMapFrom<Product>
    {
        public ProductDto()
        {
            Name = null!;
            Description = null!;
            CreatedBy = null!;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public static ProductDto Create(
            Guid id,
            string name,
            string description,
            decimal price,
            string? pictureUrl,
            string createdBy,
            DateTime createdDate,
            string? updatedBy,
            DateTime? updatedDate)
        {
            return new ProductDto
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                PictureUrl = pictureUrl,
                CreatedBy = createdBy,
                CreatedDate = createdDate,
                UpdatedBy = updatedBy,
                UpdatedDate = updatedDate
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
    }
}