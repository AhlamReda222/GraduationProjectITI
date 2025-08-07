using GraduationProjectITI.Context;
using GraduationProjectITI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GraduationProjectITI.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid Email or Password!";
            return View();
        }
    }
}
