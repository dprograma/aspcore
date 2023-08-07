using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name.");
            }
            if(obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                ModelState.AddModelError("", "Category not found.");
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                ModelState.AddModelError("", "Category not found.");
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "Category not found.");
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                ModelState.AddModelError("", "Category not found.");
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                ModelState.AddModelError("", "Category not found.");
            }
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
           
        }
    }
}

