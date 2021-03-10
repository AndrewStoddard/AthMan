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
    /// Class ClientsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ClientsController : Controller
    {
        /// <summary>
        /// The countries
        /// </summary>
        private readonly List<Country> countries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public ClientsController(AthManContext ctx)
        {
            context = ctx;
            countries = context.Countries.OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        private AthManContext context { get; }


        /// <summary>
        /// Clientses this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Clients()
        {
            return View(context.Clients.ToList());
        }

        /// <summary>
        /// Views the specified client identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult View(int clientId)
        {
            var client = context.Clients.Find(clientId);
            ViewBag.Action = "View";
            ViewBag.Countries = countries;

            return View("AddEditClient", client);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Add()
        {
            var client = new Client();
            ViewBag.Action = "Add";
            ViewBag.Countries = countries;
            return View("AddEditClient", client);
        }

        /// <summary>
        /// Edits the specified client identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Edit(int clientId)
        {
            var client = context.Clients.Find(clientId);
            ViewBag.Action = "Edit";
            ViewBag.Countries = countries;

            return View("AddEditClient", client);
        }

        /// <summary>
        /// Deletes the specified client identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Delete(int clientId)
        {
            var client = context.Clients.Find(clientId);
            context.SaveChanges();
            return View("DeleteClient", client);
        }

        /// <summary>
        /// Adds the edit.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="type">The type.</param>
        /// <returns>IActionResult.</returns>
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

        /// <summary>
        /// Deletes the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>IActionResult.</returns>
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