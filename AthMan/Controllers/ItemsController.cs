using AthMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class ItemsController : Controller
    {
        private AthManContext context { get; set; }
        public ItemsController(AthManContext ctx)
        {
            this.context = ctx;
        }
       
        public IActionResult Items()
        {
            ViewBag.Items = context.Items;
            return View();
        }
        [HttpGet]
        public IActionResult View(int itemId)
        {
            Item item = this.context.Items.Find(itemId);
            ViewBag.Action = "View";
            return View("AddEditItem", item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Item item = new Item();
            ViewBag.Action = "Add";
            return View("AddEditItem", item);
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            Item item = this.context.Items.Find(itemId);
            ViewBag.Action = "Edit";
            return View("AddEditItem", item);
        }
        [HttpGet]
        public IActionResult Delete(int itemId)
        {
            Item item = this.context.Items.Find(itemId);
            this.context.SaveChanges();
            return View("DeleteItem", item);
        }

        [HttpPost]
        public IActionResult AddEdit(Item item, string type)
        {
            if(ModelState.IsValid)
            {
                if(item.ItemID == 0)
                {
                    this.context.Items.Add(item);
                    TempData["message"] = $"{item.Name} has been added.";
                } else
                {
                    this.context.Items.Update(item);
                    TempData["message"] = $"{item.Name} has been Edited.";
                }
                this.context.SaveChanges();
                TempData["message"] = $"{item.Name} has been added.";
                return RedirectToAction("Items");
            } else
            {
                ViewBag.Action = type;
                return View("AddEditItem", item);
            }
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            this.context.Items.Remove(item);
            this.context.SaveChanges();
            TempData["message"] = $"{item.Name} has been Removed.";
            return RedirectToAction("Items");
        }



    }
}