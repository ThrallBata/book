using book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;
        private ApplicationContext db = new ApplicationContext();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            var adminName = Configuration.GetSection("Admin:Name");
            int price = 150000;
            string name = "Смартфон Apple IPhone 14 Pro Max 256Gb, голубой";
            var product = new Product { Name = name, Price = price };
            /*using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // добавляем их в бд
                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }
            using (ApplicationContext db = new)
            {
                // получаем объекты из бд и выводим на консоль
                var Products = db.Products.ToList();
                Console.WriteLine("Users list:");
                foreach (Product p in Products)
                {
                    Console.WriteLine($"{p.Id}.{p.Name} - {p.Price}");
                }
                */

                return View(product);

            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            int price = 228;
            string name = "Andrey";
            var product = new Product { Name = name, Price = price };
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}