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

        public IActionResult ElectronicJournal()
        {
            var model = studentsRepository.GetStudents();
            return View(model);
        }

        /*public IActionResult StudentsEdit(Guid id)
        {
            Student model = id == default ? new Student() : studentsRepository.GetStudentById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult StudentsEdit(Student model)
        {
            if (ModelState.IsValid)
            {
                studentsRepository.SaveStudent(model);
                return RedirectToAction("ElectronicJournal");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentsDelete(Guid id)
        {
            studentsRepository.DeleteStudent(new Student() { Id = id });
            return RedirectToAction("ElectronicJournal");
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}