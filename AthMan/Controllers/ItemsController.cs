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
    /// Class ItemsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ItemsController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public ItemsController(AthManContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        private AthManContext context { get; }

        /// <summary>
        /// Itemses this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [Route("/{controller}")]
        public IActionResult Items()
        {
            return View(context.Items.ToList());
        }

        /// <summary>
        /// Views the specified item identifier.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}/{itemId}")]
        public IActionResult View(int itemId)
        {
            var item = context.Items.Find(itemId);
            ViewBag.Action = "View";
            return View("AddEditItem", item);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}")]
        public IActionResult Add()
        {
            var item = new Item();
            ViewBag.Action = "Add";
            return View("AddEditItem", item);
        }

        /// <summary>
        /// Edits the specified item identifier.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}/{itemId}")]
        public IActionResult Edit(int itemId)
        {
            var item = context.Items.Find(itemId);
            ViewBag.Action = "Edit";
            return View("AddEditItem", item);
        }

        /// <summary>
        /// Deletes the specified item identifier.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("/{controller}/{action}/{itemId}")]
        public IActionResult Delete(int itemId)
        {
            var item = context.Items.Find(itemId);
            context.SaveChanges();
            return View("DeleteItem", item);
        }

        /// <summary>
        /// Adds the edit.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="type">The type.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddEdit(Item item, string type)
        {
            if (ModelState.IsValid)
            {
                if (item.ItemID == 0)
                {
                    context.Items.Add(item);
                    TempData["message"] = $"{item.Name} has been added.";
                }
                else
                {
                    context.Items.Update(item);
                    TempData["message"] = $"{item.Name} has been Edited.";
                }

                context.SaveChanges();
                return RedirectToAction("Items");
            }

            ViewBag.Action = type;
            return View("AddEditItem", item);
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Delete(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
            TempData["message"] = $"{item.Name} has been Removed.";
            return RedirectToAction("Items");
        }
    }
}