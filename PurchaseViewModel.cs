using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop
{
    public class PurchaseViewModel
    {
        public ProductDbContext _repository { get; set; }
        public string E_mail { get; set; }
        public double totalPrice { get; set; }

        public PurchaseViewModel()
        {

        }

        public PurchaseViewModel(ProductDbContext repository)
        {
            _repository = repository;
        }
    }
}
