using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceTracker1.Repository
{
    public class UserIdRepository : IUserIdRepository<int>
    {
        private readonly EPTDBContext _context;
        public UserIdRepository(EPTDBContext context)
        {
            _context = context;
        }
        #region getAdminId
        public async Task<int> GetAdminId(string item)
        {
            try
            {
                var adminFound = await _context.Admins.SingleOrDefaultAsync(e => e.EmailId == item);
                if (adminFound != null)
                {
                    int adminId = adminFound.AdminId;
                    return adminId;
                }
                else
                {
                    return 404;
                }
            }
            catch
            {
                return 404;
            }
        }
        #endregion

        #region getEmployeeId
        public async Task<int> GetEmployeeId(string item)
        {
            try
            {
                var employeeFound = await _context.Employees.SingleOrDefaultAsync(e => e.EmailId == item);
                if (employeeFound != null)
                {
                    int employeeId = employeeFound.EmployeeId;
                    return employeeId;
                }
                else
                {
                    return 404;
                }
            }
            catch
            {
                return 404;
            }
        }
        #endregion

        #region getMentorId
        public async Task<int> GetMentorId(string item)
        {
            try
            {
                var mentorFound = await _context.Mentors.SingleOrDefaultAsync(e => e.EmailId == item);
                if (mentorFound != null)
                {
                    int mentorId = mentorFound.MentorId;
                    return mentorId;
                }
                else
                {
                    return 404;
                }
            }
            catch
            {
                return 404;
            }
        }
        #endregion
    }
}
