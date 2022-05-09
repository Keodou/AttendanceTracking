using System.ComponentModel.DataAnnotations;

namespace AttendanceTracking.Models.Entities
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

        [Display(Name = "RFID-метка студента")]
        public string RfidId { get; set; }

        [Display(Name = "Посещаемость")]
        public bool? Attendance { get; set; }
    }
}
