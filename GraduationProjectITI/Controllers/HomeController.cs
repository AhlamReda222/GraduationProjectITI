using System.Diagnostics;
using GraduationProjectITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectITI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
    
}
