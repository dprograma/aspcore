using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            ProductViewModel producVewModel = new()
            {
                CategoryList = _db.Categories.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return View(producVewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productvm)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(productvm.Product);
                _db.SaveChanges();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                productvm.CategoryList = _db.Categories.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(productvm);
            }

           
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                ModelState.AddModelError("", "Product not found.");
            }

            Product? productFromDb = _db.Products.Find(id);
            if(productFromDb == null)
            {
                ModelState.AddModelError("", "Product not found.");
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index", "Product");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "Product not found.");
            }

            Product? productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                ModelState.AddModelError("", "Product not found.");
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product? productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                ModelState.AddModelError("", "Product not found.");
            }
            _db.Products.Remove(productFromDb);
            TempData["success"] = "Product deleted successfully.";
            _db.SaveChanges();
            return RedirectToAction("Index", "Product");
           
        }
    }
}

