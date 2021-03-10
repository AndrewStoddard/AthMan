using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
    public class ClientsController : Controller
    {
        private List<Country> countries;
        private AthManContext context { get; set; }
        public ClientsController(AthManContext ctx)
        {
            this.context = ctx;
            this.countries = this.context.Countries.OrderBy(c => c.Name).ToList();
        }
        

        public IActionResult Clients()
        {
            ViewBag.Clients = context.Clients;
            return View();
        }

        [HttpGet]
        public IActionResult View(int clientId)
        {
            Client client = this.context.Clients.Find(clientId);
            ViewBag.Action = "View";
            ViewBag.Countries = this.countries;

            return View("AddEditClient", client);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Client client = new Client();
            ViewBag.Action = "Add";
            ViewBag.Countries = countries;
            return View("AddEditClient", client);
        }

        [HttpGet]
        public IActionResult Edit(int clientId)
        {
            Client client = this.context.Clients.Find(clientId);
            ViewBag.Action = "Edit";
            ViewBag.Countries = countries;

            return View("AddEditClient", client);
        }
        [HttpGet]
        public IActionResult Delete(int clientId)
        {
            Client client = this.context.Clients.Find(clientId);
            this.context.SaveChanges();
            return View("DeleteClient", client);
        }

        [HttpPost]
        public IActionResult AddEdit(Client client)
        {
            if (ModelState.IsValid)
            {
                if (client.ClientID == 0)
                {
                    this.context.Clients.Add(client);
                    TempData["message"] = $"{client.FullName} has been added.";
                }
                else
                {
                    this.context.Clients.Update(client);
                    TempData["message"] = $"{client.FullName} has been Edited.";
                }
                this.context.SaveChanges();
                return RedirectToAction("Clients");
            }
            else
            {
                ViewBag.Countries = this.countries;
                return View("AddEditClient", client);
            }
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            this.context.Clients.Remove(client);
            this.context.SaveChanges();
            TempData["message"] = $"{client.FullName} has been Removed.";
            return RedirectToAction("Clients");
        }


    }
}