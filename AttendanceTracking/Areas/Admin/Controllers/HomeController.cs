using AttendanceTracking.Models.Entities;
using AttendanceTracking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly StudentsRepository studentsRepository;

        public HomeController(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public IActionResult Index()
        {
            var model = studentsRepository.GetStudents();
            return View(model);
        }

        public IActionResult StudentsEdit(Guid id)
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
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentsDelete(Guid id)
        {
            studentsRepository.DeleteStudent(new Student() { Id = id });
            return RedirectToAction("Index");
        }
    }
}
