using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeePerformanceTracker1.Repository
{
    public class EmployeeRepository:IEmployeeRepository<Employee>
    {
        private readonly EPTDBContext context;
        public EmployeeRepository(EPTDBContext context) => this.context = context;

        #region GetAllEmployees
        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                var records = await context.Employees.Select(e => new Employee()
                {
                    //Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    //Date = e.Date,
                    Grade = e.Grade,
                    //ProgressDescription = e.ProgressDescription,
                    EmailId = e.EmailId,
                    PhoneNo = e.PhoneNo,
                    Password = e.Password,
                    //Rating = e.Rating,
                    //Feedback = e.Feedback,
                    JobRole = e.JobRole,
                    Location = e.Location,
                    MentorId = e.MentorId,
                    Mentor = e.Mentor,


                }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetById
        public async Task<Employee> GetById(int id)
        {
            try
            {
                var employee = await context.Employees.Where(e => e.EmployeeId == id).Select(e => new Employee()
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    Grade = e.Grade,
                    PhoneNo = e.PhoneNo,
                    Location = e.Location,
                    JobRole = e.JobRole,
                    EmailId = e.EmailId,
                    Password = e.Password,
                    MentorId = e.MentorId,
                    Mentor = e.Mentor
                }).FirstOrDefaultAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region getbymentorid
        public async Task<IEnumerable<Employee>> GetByMentorId(int MentorId)
        {
            try
            {
                var record = await context.Employees.Where(e => e.MentorId == MentorId).Select(e => new Employee()
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    MentorId = e.MentorId,

                    Mentor = e.Mentor,
                    //MentorName = e.MentorName,
                    //Date = e.Date,
                    Grade = e.Grade,
                    //ProgressDescription = e.ProgressDescription,
                    EmailId = e.EmailId,
                    PhoneNo = e.PhoneNo,
                    //Password = e.Password,
                    //Rating = e.Rating,
                    //Feedback = e.Feedback,
                    //Role = e.Role,
                    Location = e.Location,

                }).ToListAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region insertEmployee
        public async Task<Employee> SaveRecord(Employee entity)
        {
            try
            {
                var e = new Employee()
                {
                    //Id =entity.Id  ,
                    EmployeeId = entity.EmployeeId,
                    EmployeeName = entity.EmployeeName,
                    //Date = entity.Date,
                    Grade = entity.Grade,
                    //ProgressDescription=entity.ProgressDescription,
                    EmailId = entity.EmailId,
                    PhoneNo = entity.PhoneNo,
                    Password = entity.Password,
                    // Rating=entity.Rating,
                    //Feedback=entity.Feedback,
                    JobRole = entity.JobRole,
                    Location = entity.Location,
                    MentorId = entity.MentorId,


                };
                context.Employees.Add(e);
                await context.SaveChangesAsync();
                return e;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region updateEmployee
        public async Task<Employee> UpdateRecord(Employee entity)
        {
            try
            {
                var employee = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == entity.EmployeeId);
                if (employee != null)
                {
                    employee.EmployeeId = entity.EmployeeId;
                    employee.EmployeeName = entity.EmployeeName;
                    //employee.Date = entity.Date;
                    employee.Grade = entity.Grade;
                    //employee.ProgressDescription=entity.ProgressDescription;    
                    employee.EmailId = entity.EmailId;
                    employee.PhoneNo = entity.PhoneNo;
                    employee.Password = entity.Password;
                    //employee.Rating=entity.Rating;
                    //employee.Feedback=entity.Feedback;
                    employee.JobRole = entity.JobRole;
                    employee.Location = entity.Location;
                    employee.MentorId = entity.MentorId;
                    context.SaveChanges();
                }
                return employee;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
