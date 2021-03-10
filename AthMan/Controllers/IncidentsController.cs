using System.Collections.Generic;
using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly List<Client> clients;
        private readonly List<Employee> employees;
        private readonly List<Item> items;

        public IncidentsController(AthManContext ctx)
        {
            context = ctx;
            clients = context.Clients.OrderBy(c => c.ClientID).ToList();
            employees = context.Employees.OrderBy(e => e.EmployeeID).ToList();
            items = context.Items.OrderBy(i => i.ItemID).ToList();
        }

        private AthManContext context { get; }

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

        [HttpGet]
        public IActionResult View(int incidentId)
        {
            var incident = context.Incidents.Find(incidentId);
            ViewBag.Action = "View";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var incident = new Incident();
            ViewBag.Action = "Add";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }

        [HttpGet]
        public IActionResult Edit(int incidentId)
        {
            var incident = context.Incidents.Find(incidentId);
            ViewBag.Action = "Edit";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }


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