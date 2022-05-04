using AttendanceTracking.Models;
using AttendanceTracking.Models.Entities;
using AttendanceTracking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AttendanceTracking.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly StudentsRepository studentsRepository;

        public HomeController(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ElectronicJournal(string group)
        {
            ViewData["Group90001997SortParm"] = string.IsNullOrEmpty(group) ? "90001997" : "";
            var model = studentsRepository.GetStudents(group);

            switch (group)
            {
                case "Group90001997SortParm":
                    model = studentsRepository.GetStudents("90001997");
                    break;

                case "90001996":
                    model = studentsRepository.GetStudents("90001996");
                    break;

                case "90001995":
                    model = studentsRepository.GetStudents("90001997");
                    break;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}