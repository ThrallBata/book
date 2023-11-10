using book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using book.Database;

namespace book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;
        // private ApplicationContext db = new ApplicationContext();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            /*
            var products = new List<Product> 
            { 
                new Product{
                   Id = 1,
                   Name = "A Song of Ice and Fire",
                   Price = 100,
                   Slug = "IceandFire",
                   Categories = {},
                },
               new Product { Id = 2, Name = "The Lord of the Rings", Price = 200,
                             Slug = "LordoftheRings",
                   Categories = { }
               },
               new Product { Id = 3, Name = "War and peace", Price = 300,
                             Slug = "Warandpeace",
                   Categories = { }
               }
            };

            var categorys = new List<Category>
            {
                new Category { Id = 1, Name = "Fantastic", Slug = "Fantastic" }
            };*/

            List<Product> Products;
            using (ApplicationContext db = new ApplicationContext())
            {
                Products = db.Products.ToList();

            }


            return View(Products);


        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}