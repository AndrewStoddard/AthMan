// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    /// <summary>
    /// Class IncidentsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class IncidentsController : Controller
    {
        /// <summary>
        /// The clients
        /// </summary>
        private readonly List<Client> clients;
        /// <summary>
        /// The employees
        /// </summary>
        private readonly List<Employee> employees;
        /// <summary>
        /// The items
        /// </summary>
        private readonly List<Item> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncidentsController"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public IncidentsController(AthManContext ctx)
        {
            context = ctx;
            clients = context.Clients.OrderBy(c => c.ClientID).ToList();
            employees = context.Employees.OrderBy(e => e.EmployeeID).ToList();
            items = context.Items.OrderBy(i => i.ItemID).ToList();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        private AthManContext context { get; }

        /// <summary>
        /// Incidentses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [Route("/{controller}/{id?}")]
        public IActionResult Incidents(string id = "all")
        {
            List<Incident> incidents;
            if (id == "noemployee")
                incidents = context.Incidents.Where(incident => incident.EmployeeID == null).ToList();
            else if (id == "open")
                incidents = context.Incidents.Where(incident => incident.DateClosed == null).ToList();
            else
                incidents = context.Incidents.ToList();

            ViewBag.SelectedFilter = id;
            return View(incidents);
        }

        /// <summary>
        /// Views the specified incident identifier.
        /// </summary>
        /// <param name="incidentId">The incident identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}/{incidentId}")]
        public IActionResult View(int incidentId)
        {
            var incident = context.Incidents.Find(incidentId);
            ViewBag.Action = "View";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}")]
        public IActionResult Add()
        {
            var incident = new Incident();
            ViewBag.Action = "Add";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }

        /// <summary>
        /// Edits the specified incident identifier.
        /// </summary>
        /// <param name="incidentId">The incident identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}/{incidentId}")]
        public IActionResult Edit(int incidentId)
        {
            var incident = context.Incidents.Find(incidentId);
            ViewBag.Action = "Edit";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }


        /// <summary>
        /// Adds the edit.
        /// </summary>
        /// <param name="incident">The incident.</param>
        /// <param name="type">The type.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddEdit(Incident incident, string type)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                    TempData["message"] = "Incident has been added.";
                }
                else
                {
                    context.Incidents.Update(incident);
                    TempData["message"] = $"Incident {incident.IncidentID} has been Edited.";
                }

                context.SaveChanges();
                return RedirectToAction("Incidents");
            }

            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            ViewBag.Action = type;
            return View("AddEditIncident", incident);
        }
    }
}