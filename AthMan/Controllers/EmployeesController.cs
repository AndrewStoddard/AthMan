using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class EmployeesController : Controller
    {
        private AthManContext context { get; set; }
        public EmployeesController(AthManContext ctx)
        {
            this.context = ctx;
        }
      
        public IActionResult Employees()
        {
            ViewBag.Employees = context.Employees;
            return View();
        }
   

    }
}