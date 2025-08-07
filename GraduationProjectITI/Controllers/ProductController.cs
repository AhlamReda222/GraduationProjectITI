using GraduationProjectITI.Context;
using GraduationProjectITI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectITI.Controllers
{
    public class ProductController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult Index()
        {
            var products = db.Products.Include(p => p.category).ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var products = db.Products.Include(p => p.category).FirstOrDefault(p => p.ProductId == id);
            if (products == null)
            {
                return RedirectToAction("Index");
            }
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.category = new SelectList(db.Gategories, "CategoryId", "Name", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                string fullPath = Path.Combine(wwwRootPath, "images", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                product.ImagePath = "/images/" + fileName; 
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.category = new SelectList(db.Gategories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product, IFormFile ImageFile)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
            {
                return RedirectToAction("Index");
            }

            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.CategoryId = product.CategoryId;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                string fullPath = Path.Combine(wwwRootPath, "images", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                existingProduct.ImagePath = "/images/" + fileName;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}