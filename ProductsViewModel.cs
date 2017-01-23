using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop
{
    public class ProductsViewModel
    {
        public ProductDbContext _repository { get; set; }
        public Category SelectedCategory { get; set; }

        public ProductsViewModel()
        {

        }

        public ProductsViewModel(ProductDbContext repository)
        {
            _repository = repository;
        }
    }
}
