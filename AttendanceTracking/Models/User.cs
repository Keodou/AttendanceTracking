using System.ComponentModel.DataAnnotations;

namespace AttendanceTracking.Models
{
    public class User
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль от учетной записи")]
        public string Password { get; set; }
    }
}
