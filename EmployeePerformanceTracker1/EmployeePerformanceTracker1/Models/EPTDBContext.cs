using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceTracker1.Models
{
    public class EPTDBContext: DbContext
    {
        public EPTDBContext(DbContextOptions<EPTDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Progress> progresses { get; set; }
    }
}
