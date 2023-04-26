using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerformanceTracker1.Models
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Progress Description")]
        public string ProgressDescription { get; set; }

        public int EmployeeId { get; set; }
        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
