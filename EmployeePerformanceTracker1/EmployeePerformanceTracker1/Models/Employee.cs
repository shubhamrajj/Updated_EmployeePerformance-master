using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerformanceTracker1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Role")]
        public string JobRole { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password length is inappropriate")]
        public string Password { get; set; }

        [Display(Name = "Mentor Id")]

        public int MentorId { get; set; }

        [ValidateNever]
        public Mentor Mentor { get; set; }
    }
}
