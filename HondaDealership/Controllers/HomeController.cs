using HondaDealership.Models;
using HondaDealership.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace HondaDealership.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext context { get; set; }
        private readonly IRepository<Honda> _repository;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx, IRepository<Honda> repository)
        {
            _logger = logger;
            context = ctx;
            _repository = repository;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["YearSortParm"] = string.IsNullOrEmpty(sortOrder) ? "year_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

            var options = new QueryOptions<Honda>();

            switch (sortOrder)
            {
                case "price":
                    options.OrderBy = m => m.VehPrice;
                    options.OrderByDescending = false;
                    break;
                case "price_desc":
                    options.OrderBy = m => m.VehPrice;
                    options.OrderByDescending = true;
                    break;
                default:
                    options.OrderBy = m => m.VehYear;
                    break;
            }
               
            var hondas = _repository.GetAll(options).ToList();
            return View("~/Views/Home/Index.cshtml", hondas);
        }

        public IActionResult Privacy()
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