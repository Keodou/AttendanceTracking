using AttendanceTracking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AttendanceTracking.Controllers
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

        public IActionResult ElectronicJournal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginForm(User user)
        {
            if (ModelState.IsValid)
            {
                return View("ElectronicJournal");
            }

            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public ViewResult Index() 
        { 
            return View("WelcomePage"); 
        }

        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult LoginForm(User user)
        {
            if (ModelState.IsValid)
            {
                return View("ElectronicJournal");
            }

            else
            {
                return View();
            }
        }*/
    }
}