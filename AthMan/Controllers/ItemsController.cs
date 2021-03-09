using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ItemsController : Controller
    {
        private AthManContext context { get; set; }
        public ItemsController(AthManContext ctx)
        {
            this.context = ctx;
        }
       
        public IActionResult Items()
        {
            ViewBag.Items = context.Items;
            return View();
        }

       

    }
}