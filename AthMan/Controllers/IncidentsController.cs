using System.Collections.Generic;
using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class IncidentsController : Controller
    {
        private AthManContext context { get; set; }
        private List<Client> clients;
        private List<Employee> employees;
        private List<Item> items;
        public IncidentsController(AthManContext ctx)
        {
            this.context = ctx;
            this.clients = this.context.Clients.OrderBy(c => c.ClientID).ToList();
            this.employees = this.context.Employees.OrderBy(e => e.EmployeeID).ToList();
            this.items = this.context.Items.OrderBy(i => i.ItemID).ToList();
        }
      
        public IActionResult Incidents(string id = "all")
        {
            List<Incident> incidents;
            if (id == "noemployee")
            {
                incidents = this.context.Incidents.Where(incident => incident.EmployeeID == null).ToList();
            }
            else if (id == "open")
            {
                incidents = this.context.Incidents.Where(incident => incident.DateClosed == null).ToList();

            }
            else
            {
                incidents = this.context.Incidents.ToList();
            }

            ViewBag.SelectedFilter = id;
            return View(incidents);
        }
        [HttpGet]
        public IActionResult View(int incidentId)
        {
            Incident incident = this.context.Incidents.Find(incidentId);
            ViewBag.Action = "View";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Incident incident = new Incident();
            ViewBag.Action = "Add";
            ViewBag.Clients = clients;
            ViewBag.Employees = employees;
            ViewBag.Items = items;
            return View("AddEditIncident", incident);
        }

        [HttpGet]
        public IActionResult Edit(int incidentId)
        {
            Incident incident = this.context.Incidents.Find(incidentId);
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
                    this.context.Incidents.Add(incident);
                    TempData["message"] = $"Incident has been added.";
                }
                else
                {
                    this.context.Incidents.Update(incident);
                    TempData["message"] = $"Incident {incident.IncidentID} has been Edited.";
                }
                this.context.SaveChanges();
                return RedirectToAction("Incidents");
            }
            else
            {
                ViewBag.Clients = clients;
                ViewBag.Employees = employees;
                ViewBag.Items = items;
                ViewBag.Action = type;
                return View("AddEditIncident", incident);
            }
        }

        

    }
}