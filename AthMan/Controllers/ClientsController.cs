using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ClientsController : Controller
    {
        private AthManContext context { get; set; }
        public ClientsController(AthManContext ctx)
        {
            this.context = ctx;
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
            return View("AddEditClient", client);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Client client = new Client();
            ViewBag.Action = "Add";
            return View("AddEditClient", client);
        }

        [HttpGet]
        public IActionResult Edit(int clientId)
        {
            Client client = this.context.Clients.Find(clientId);
            ViewBag.Action = "Edit";
            return View("AddEditClient", client);
        }
        [HttpGet]
        public IActionResult Delete(int clientId)
        {
            Client client = this.context.Clients.Find(clientId);
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
                }
                else
                {
                    this.context.Clients.Update(client);
                }
                this.context.SaveChanges();
                return RedirectToAction("Clients");
            }
            else
            {
                return View("AddEdit", client);
            }
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            this.context.Clients.Remove(client);
            this.context.SaveChanges();
            return RedirectToAction("Clients");
        }


    }
}