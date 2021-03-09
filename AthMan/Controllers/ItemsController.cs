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
        public IActionResult AddEdit(Item item)
        {
            if(ModelState.IsValid)
            {
                if(item.ItemID == 0)
                {
                    this.context.Items.Add(item);
                } else
                {
                    this.context.Items.Update(item);
                }
                this.context.SaveChanges();
                return RedirectToAction("Items");
            } else
            {
                return View("AddEdit", item);
            }
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            this.context.Items.Remove(item);
            this.context.SaveChanges();
            return RedirectToAction("Items");
        }



    }
}