using Microsoft.AspNetCore.Mvc;
using ParrotWeightTracker.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ParrotWeightTracker.Controllers
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
            if (User.Identity.IsAuthenticated)
            {
                TempData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); // Depends on the type of authentication
                TempData["UserName"] = User.Identity.Name;
                TempData["Email"] = User.FindFirstValue(ClaimTypes.Email);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
