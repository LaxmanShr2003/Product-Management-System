using laxmanPMS.Infrastructure.IRepository.ICrudService;
using laxmanPMS.Models.Entity;
using laxmanPMS.Models.ViewModels;
using laxmanPMS.web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace laxmanPMS.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrudService<Category> _categoryCrudService;
        private readonly ICrudService<Product> _productCrudService;
      
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            ICrudService<Product> productCrudService,
            UserManager<ApplicationUser> usermanager,

ICrudService<Category> categoryCrudService)
        {

            _productCrudService = productCrudService;
            _userManager = usermanager;
            _categoryCrudService = categoryCrudService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryInfos = await _categoryCrudService.GetAllAsync();
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.products = await _productCrudService.GetAllAsync(e =>e.IsAvailable);


            return View(productViewModel);
        }

        public async Task<IActionResult> search(ProductViewModel productViewModel)
        {
            ViewBag.CategoryInfos = await _categoryCrudService.GetAllAsync();
            productViewModel.products = await _productCrudService.GetAllAsync(e=>e.CategoryId==productViewModel.searchViewModel.categoryId);
        productViewModel.products = productViewModel.products.Where(p => Regex.IsMatch(p.ProductName, "^" + productViewModel.searchViewModel.ProductName + ".*$"));

            return View("Index", productViewModel);
        }

        public async Task<IActionResult> Home(int id)
        {

          return View();
        }

      
    }
}
