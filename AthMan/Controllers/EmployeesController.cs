// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    /// <summary>
    /// Class EmployeesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class EmployeesController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public EmployeesController(AthManContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        private AthManContext context { get; }

        /// <summary>
        /// Employeeses this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Employees()
        {
            return View(context.Employees.ToList());
        }

        /// <summary>
        /// Views the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult View(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            ViewBag.Action = "View";
            return View("AddEditEmployee", employee);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Add()
        {
            var employee = new Employee();
            ViewBag.Action = "Add";
            return View("AddEditEmployee", employee);
        }

        /// <summary>
        /// Edits the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            ViewBag.Action = "Edit";
            return View("AddEditEmployee", employee);
        }

        /// <summary>
        /// Deletes the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            context.SaveChanges();
            return View("DeleteEmployee", employee);
        }

        /// <summary>
        /// Adds the edit.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="type">The type.</param>
        /// <returns>IActionResult.</returns>
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

        /// <summary>
        /// Deletes the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>IActionResult.</returns>
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