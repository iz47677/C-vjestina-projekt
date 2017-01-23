using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public bool IsSelected { get; set; }

        public Product(string name, string description, string category, double price)
        {
            Id = Guid.NewGuid(); // Generates new unique identifier
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            IsSelected = false;
        }

        public Product()
        {

        }
    }
}
