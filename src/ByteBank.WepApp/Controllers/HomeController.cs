using ByteBank.WepApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ByteBank.WepApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public IActionResult Index() => View();

        public IActionResult PrincipalHome() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}