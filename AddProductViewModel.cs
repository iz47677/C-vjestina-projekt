using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public ProductDbContext _repository { get; set; }

        public AddProductViewModel()
        {

        }

        public AddProductViewModel(ProductDbContext repository)
        {
            _repository = repository;
        }
    }
}
