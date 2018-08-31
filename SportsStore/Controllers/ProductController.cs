using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        /* When MVC needs to create a new instance of the ProductController class to handle an
           HTTP request, it will inspect the constructor and see that it requires an object that implements
           the IProductRepository interface. To determine what implementation class should be used,
           MVC consults the configuration in the Startup class, which tells it that FakeRepository should
           be used and that a new instance should be created every time. MVC creates a new
           FakeRepository object and uses it to invoke the ProductController constructor in order to
           create the controller object that will process the HTTP request.
               This is known as dependency injection, and its approach allows the ProductController to
           access the application’s repository through the IProductRepository interface without having 
           any need to know which implementation class has been configured. Later, I’ll replace the fake
           repository with the real one, and dependency injection means that the controller will continue
           to work without changes.
        */
        public ProductController(IProductRepository repo) {
            repository = repo;
        }

        public ViewResult List(int page = 1) => View(new ProductsListViewModel {
            Products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}