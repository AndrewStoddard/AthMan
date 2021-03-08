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
    }
}