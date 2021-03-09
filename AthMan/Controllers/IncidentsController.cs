using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class IncidentsController : Controller
    {
        private AthManContext context { get; set; }
        public IncidentsController(AthManContext ctx)
        {
            this.context = ctx;
        }
      
        public IActionResult Incidents()
        {
            ViewBag.Incidents = context.Incidents;
            return View();
        }

    }
}