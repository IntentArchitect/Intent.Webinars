using System;
using AutoMapper;
using CleanArchitecture.Test.Application.Common.Mappings;
using CleanArchitecture.Test.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CleanArchitecture.Test.Application.Customers
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public CustomerDto()
        {
            CreatedBy = null!;
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public static CustomerDto Create(
            Guid id,
            string createdBy,
            DateTime createdDate,
            string? updatedBy,
            DateTime? updatedDate)
        {
            return new CustomerDto
            {
                Id = id,
                CreatedBy = createdBy,
                CreatedDate = createdDate,
                UpdatedBy = updatedBy,
                UpdatedDate = updatedDate
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>();
        }
    }
}