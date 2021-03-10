using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(AthManContext ctx)
        {
            context = ctx;
        }

        private AthManContext context { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}