using AttendanceTracking.Models;
using AttendanceTracking.Models.Entities;
using AttendanceTracking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AttendanceTracking.Controllers
{
    public class JournalController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly StudentsRepository _studentsRepository;

        public JournalController(StudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string group)
        {
            var model = _studentsRepository.GetStudents();
            return View(model);
        }

        public IActionResult StudentsEdit(int id)
        {
            Student model = id == default ? new Student() : _studentsRepository.GetStudentById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult StudentsEdit(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentsRepository.SaveStudent(model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentsDelete(int id)
        {
            _studentsRepository.DeleteStudent(new Student() { Id = id });
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}