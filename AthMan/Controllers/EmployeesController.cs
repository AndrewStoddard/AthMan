using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeesController(AthManContext ctx)
        {
            context = ctx;
        }

        private AthManContext context { get; }

        public IActionResult Employees()
        {
            return View(context.Employees.ToList());
        }

        [HttpGet]
        public IActionResult View(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            ViewBag.Action = "View";
            return View("AddEditEmployee", employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var employee = new Employee();
            ViewBag.Action = "Add";
            return View("AddEditEmployee", employee);
        }

        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            ViewBag.Action = "Edit";
            return View("AddEditEmployee", employee);
        }

        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            context.SaveChanges();
            return View("DeleteEmployee", employee);
        }

        [HttpPost]
        public IActionResult AddEdit(Employee employee, string type)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeID == 0)
                {
                    context.Employees.Add(employee);
                    TempData["message"] = $"{employee.Name} has been added.";
                }
                else
                {
                    context.Employees.Update(employee);
                    TempData["message"] = $"{employee.Name} has been Edited.";
                }

                context.SaveChanges();

                return RedirectToAction("Employees");
            }

            ViewBag.Action = type;
            return View("AddEditEmployee", employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
            TempData["message"] = $"{employee.Name} has been Removed.";
            return RedirectToAction("Employees");
        }
    }
}