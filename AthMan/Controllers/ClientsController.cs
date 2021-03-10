using System.Collections.Generic;
using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ClientsController : Controller
    {
        private readonly List<Country> countries;

        public ClientsController(AthManContext ctx)
        {
            context = ctx;
            countries = context.Countries.OrderBy(c => c.Name).ToList();
        }

        private AthManContext context { get; }


        public IActionResult Clients()
        {
            return View(context.Clients.ToList());
        }

        [HttpGet]
        public IActionResult View(int clientId)
        {
            var client = context.Clients.Find(clientId);
            ViewBag.Action = "View";
            ViewBag.Countries = countries;

            return View("AddEditClient", client);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var client = new Client();
            ViewBag.Action = "Add";
            ViewBag.Countries = countries;
            return View("AddEditClient", client);
        }

        [HttpGet]
        public IActionResult Edit(int clientId)
        {
            var client = context.Clients.Find(clientId);
            ViewBag.Action = "Edit";
            ViewBag.Countries = countries;

            return View("AddEditClient", client);
        }

        [HttpGet]
        public IActionResult Delete(int clientId)
        {
            var client = context.Clients.Find(clientId);
            context.SaveChanges();
            return View("DeleteClient", client);
        }

        [HttpPost]
        public IActionResult AddEdit(Client client, string type)
        {
            if (ModelState.IsValid)
            {
                if (client.ClientID == 0)
                {
                    context.Clients.Add(client);
                    TempData["message"] = $"{client.FullName} has been added.";
                }
                else
                {
                    context.Clients.Update(client);
                    TempData["message"] = $"{client.FullName} has been Edited.";
                }

                context.SaveChanges();
                return RedirectToAction("Clients");
            }

            ViewBag.Action = type;
            ViewBag.Countries = countries;
            return View("AddEditClient", client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
            TempData["message"] = $"{client.FullName} has been Removed.";
            return RedirectToAction("Clients");
        }
    }
}