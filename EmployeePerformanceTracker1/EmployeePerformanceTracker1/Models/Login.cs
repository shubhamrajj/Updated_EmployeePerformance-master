using System.ComponentModel.DataAnnotations;
namespace EmployeePerformanceTracker1.Models
{
    public class Login
    {
        [Required]

        public string Role { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
