using System.ComponentModel.DataAnnotations;

namespace AttendanceTracking.Models
{
    public class Student
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Имя студента")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Группа студента")]
        public string Group { get; set; }

        [Display(Name = "Посещаемость")]
        public string? Attendance { get; set; }
    }
}
