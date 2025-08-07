using GraduationProjectITI.Context;
using GraduationProjectITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectITI.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult Index()
        {
            var categories = db.Gategories.ToList();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = db.Gategories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return RedirectToAction("Index");

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Gategories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = db.Gategories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return RedirectToAction("Index");

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Gategories.Update(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = db.Gategories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return RedirectToAction("Index");

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = db.Gategories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                db.Gategories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
