using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _repository;

        public ProductsController(ProductDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewData["Category"] = "null";
            return View(new ProductsViewModel(_repository));
        }

        [HttpGet]
        public IActionResult Index(ProductsViewModel model)
        {
            ViewData["Category"] = model.SelectedCategory._category;
            return View(new ProductsViewModel(_repository));
        }

        public IActionResult Categories()
        {
            return View(_repository);
        }

        public IActionResult RemoveCategory(Category category)
        {
            _repository.Categories.Remove(category);
            _repository.SaveChanges();
            return Categories();
        }

        public IActionResult AddProduct()
        {
            ViewData["ErrorProduct"] = "false";
            return View(new AddProductViewModel(_repository));
        }

        public IActionResult RemoveProduct(Product product)
        {
            _repository.Products.Remove(product);
            _repository.SaveChanges();
            return View("Index", new ProductsViewModel(_repository));
        }

        public IActionResult AddCategory()
        {
            ViewData["ErrorCategory"] = "false";
            return View();
        }

        public IActionResult Cart()
        {
            ViewData["ErrorCartEmail"] = "false";
            ViewData["ErrorCartEmpty"] = "false";
            return View(new PurchaseViewModel(_repository));
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (model.Name == null || model.Description == null || model.Category == null || model.Price == null)
            {
                ViewData["ErrorProduct"] = "true";
                return View(new AddProductViewModel(_repository));
            }
            _repository.Products.Add(new Product(model.Name, model.Description, model.Category._category, model.Price));
            _repository.SaveChanges();
            return View("Index", new ProductsViewModel(_repository));
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (model.Name == null)
            {
                ViewData["ErrorCategory"] = "true";
                return View();
            }
            _repository.Categories.Add(new Category(model.Name));
            _repository.SaveChanges();
            return View("Categories", _repository);
        }

        public IActionResult AddToCart(Product product)
        {
            Product selectedProduct = _repository.Products.Where(i => i.Id == product.Id).FirstOrDefault();
            selectedProduct.IsSelected = true;
            _repository.Products.Remove(product);
            _repository.Products.Add(selectedProduct);
            _repository.SaveChanges();
            return View("Index", new ProductsViewModel(_repository));
        }

        public IActionResult RemoveFromCart(Product product)
        {
            _repository.Products.Remove(product);
            _repository.SaveChanges();
            return Cart();
        }

        public IActionResult Orders()
        {
            return View(_repository);
        }

        public IActionResult Buy(PurchaseViewModel Purchase)
        {
            if (_repository.Products.Where(i => i.IsSelected == true) == null)
            {
                ViewData["ErrorCartEmpty"] = "true";
                ViewData["ErrorCartEmail"] = "false";
                return View("Cart", new PurchaseViewModel(_repository));
            }
            if (Purchase.E_mail == null)
            {
                ViewData["ErrorCartEmail"] = "true";
                ViewData["ErrorCartEmpty"] = "false";
                return View("Cart", new PurchaseViewModel(_repository));
            }
            _repository.Orders.Add(Purchase);
            _repository.SaveChanges();
            return Index();
        }

        public IActionResult Details(Product product)
        {
            return View(product);
        }
    }
}
