
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HondaDealership.Models;
using HondaDealership.Models.DataLayer;
using Microsoft.EntityFrameworkCore;



namespace HondaDealership.Controllers
{
    [Authorize]
    public class HondaController : Controller
    {
        private UnitOfWork hondaData { get; set; }

        public HondaController(ApplicationDbContext ctx)
        {
            hondaData = new UnitOfWork(ctx);
        }

        [AllowAnonymous]
        public IActionResult Index(string sortOrder)
        {
            ViewData["YearSortParm"] = string.IsNullOrEmpty(sortOrder) ? "year_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

            var options = new QueryOptions<Honda>();

            switch (sortOrder)
            {
                case "Price":
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

            var hondas = hondaData.Hondas.GetAll(options).ToList();
            return View("~/Views/Home/Index.cshtml", hondas);
        }
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Honda());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var honda = hondaData.Hondas.Find(id);
            return View(honda);
        }

        [HttpPost]
        public IActionResult Edit(Honda honda)
        {

            if (ModelState.IsValid)
            {
                if (honda.Id == 0)
                    hondaData.Hondas.Insert(honda);
                else
                    hondaData.Hondas.Update(honda);
                hondaData.Hondas.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (honda.Id == 0) ? "Add" : "Edit";
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {

            var honda = hondaData.Hondas.Find(id);
            return View(honda);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Honda honda)
        {
            hondaData.Hondas.Delete(honda);
            hondaData.Hondas.Save();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
