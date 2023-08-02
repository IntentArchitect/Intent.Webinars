using System;
using CleanArchitecture.Test.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CleanArchitecture.Test.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest, ICommand
    {
        public UpdateProductCommand(string name, string description, decimal price, string? pictureUrl, Guid id)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            Id = id;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public Guid Id { get; set; }
    }
}