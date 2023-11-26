using book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using book.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;
       
        private readonly ApplicationContext Context;
        public IEnumerable<Product> Products { get; set; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationContext context)
        {
            _logger = logger;
            Configuration = configuration;
            Context = context;
        }
        public IActionResult Index()
        {
           /* Product p1 = new Product
            {
                Name = "A Song of Ice and Fire",
                Price = 100,
                Slug = "IceandFire",
                Categories = { },
            };
            

            // добавление
            Context.Products.Add(p1);
            Context.SaveChanges();*/

            Products = Context.Products.ToList();

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