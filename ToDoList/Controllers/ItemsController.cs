using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList();
      return View(model);
    }

    public ActionResult Create() // GET action to display our form to user
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Item item) // POST action to manage form submission
    {
        _db.Items.Add(item); 
        _db.SaveChanges();
        return RedirectToAction("Index"); //afterwards redirect to index
    }
    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      // ()

      return View(thisItem);
    }
  }
}