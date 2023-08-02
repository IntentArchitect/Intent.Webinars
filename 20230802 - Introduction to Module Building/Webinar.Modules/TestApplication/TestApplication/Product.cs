using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.BasicEntities.Entity", Version = "1.0")]

namespace TestApplication
{
    public class Product
    {
        public Product(string name, string description, decimal price, byte[] pictureUrl)
        {
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] PictureUrl { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}