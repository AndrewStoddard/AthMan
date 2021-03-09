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

        [HttpGet]
        public IActionResult View(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            ViewBag.Action = "View";
            return View("AddEditEmployee", employee);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Employee employee = new Employee();
            ViewBag.Action = "Add";
            return View("AddEditEmployee", employee);
        }

        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            ViewBag.Action = "Edit";
            return View("AddEditEmployee", employee);
        }
        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            return View("DeleteEmployee", employee);
        }

        [HttpPost]
        public IActionResult AddEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeID == 0)
                {
                    this.context.Employees.Add(employee);
                }
                else
                {
                    this.context.Employees.Update(employee);
                }
                this.context.SaveChanges();
                return RedirectToAction("Employees");
            }
            else
            {
                return View("AddEdit", employee);
            }
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            this.context.Employees.Remove(employee);
            this.context.SaveChanges();
            return RedirectToAction("Employees");
        }


    }
}