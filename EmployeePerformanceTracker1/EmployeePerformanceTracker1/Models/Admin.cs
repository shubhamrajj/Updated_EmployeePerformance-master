using System.ComponentModel.DataAnnotations;

namespace EmployeePerformanceTracker1.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required, Display(Name = "Name")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="Password length is wrong")]
        public string Password { get; set; }

        [Display(Name = "Role")]

        public string JobRole { get; set; }
    }
}
