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
      
        public IActionResult Incidents()
        {
            ViewBag.Incidents = context.Incidents;
            return View();
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
        public IActionResult AddEdit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    this.context.Incidents.Add(incident);
                }
                else
                {
                    this.context.Incidents.Update(incident);
                }
                this.context.SaveChanges();
                return RedirectToAction("Incidents");
            }
            else
            {
                ViewBag.Clients = clients;
                ViewBag.Employees = employees;
                ViewBag.Items = items;
                return View("AddEditIncident", incident);
            }
        }

        

    }
}