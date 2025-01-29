using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name = "Keyboard" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}
