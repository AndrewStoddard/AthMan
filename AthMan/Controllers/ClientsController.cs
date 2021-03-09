using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ClientsController : Controller
    {
        private AthManContext context { get; set; }
        public ClientsController(AthManContext ctx)
        {
            this.context = ctx;
        }
        

        public IActionResult Clients()
        {
            ViewBag.Clients = context.Clients;
            return View();
        }
       

    }
}