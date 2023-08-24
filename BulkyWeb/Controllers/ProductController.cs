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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
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

            if (id == null || id == 0) {
                return View(producVewModel);
            }
            else {
                producVewModel.Product = _db.Products.Single(u => u.Id==id);
                return View(producVewModel);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel productvm, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(ModelState.IsValid)
            {
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productvm.Product.ImageUrl = @"/images/product/" + fileName;

                }
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

