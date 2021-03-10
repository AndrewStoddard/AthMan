using System.Linq;
using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ItemsController : Controller
    {
        public ItemsController(AthManContext ctx)
        {
            context = ctx;
        }

        private AthManContext context { get; }

        public IActionResult Items()
        {
            return View(context.Items.ToList());
        }

        [HttpGet]
        public IActionResult View(int itemId)
        {
            var item = context.Items.Find(itemId);
            ViewBag.Action = "View";
            return View("AddEditItem", item);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var item = new Item();
            ViewBag.Action = "Add";
            return View("AddEditItem", item);
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var item = context.Items.Find(itemId);
            ViewBag.Action = "Edit";
            return View("AddEditItem", item);
        }

        [HttpGet]
        public IActionResult Delete(int itemId)
        {
            var item = context.Items.Find(itemId);
            context.SaveChanges();
            return View("DeleteItem", item);
        }

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