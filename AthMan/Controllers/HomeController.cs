using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class HomeController : Controller
    {
        private AthManContext context { get; set; }
        public HomeController(AthManContext ctx)
        {
            this.context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Items()
        {
            ViewBag.Items = context.Items;
            return View();
        }

        public IActionResult Clients()
        {
            ViewBag.Clients = context.Clients;
            return View();
        }
        public IActionResult Employees()
        {
            ViewBag.Employees = context.Employees;
            return View();
        }
        public IActionResult Incidents()
        {
            ViewBag.Incidents = context.Incidents;
            return View();
        }

    }
}