using AttendanceTracking.Models.Entities;
using AttendanceTracking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly StudentsRepository studentsRepository;

        public StudentsController(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public IActionResult Index(string group)
        {
            ViewData["Group90001997SortParm"] = string.IsNullOrEmpty(group) ? "90001997" : "90001997";
            ViewData["Group90001996SortParm"] = string.IsNullOrEmpty(group) ? "90001996" : "90001996";
            ViewData["Group90001995SortParm"] = string.IsNullOrEmpty(group) ? "90001995" : "90001995";

            var model = studentsRepository.GetStudents(group);

            switch (group)
            {
                case "Group90001997SortParm":
                    model = studentsRepository.GetStudents("90001997");
                    break;

                case "Group90001996SortParm":
                    model = studentsRepository.GetStudents("90001996");
                    break;

                case "Group90001995SortParm":
                    model = studentsRepository.GetStudents("90001997");
                    break;
            }
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
