using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceTracker1.Repository
{
    public class MentorRepository:IMentorRepository<Mentor>
    {
        private readonly EPTDBContext _dbcontext;
        public MentorRepository(EPTDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region GetMentorDetailsById

        public async Task<Mentor> GetMentorDetailsById(int id)
        {
            try
            {
                var mentor = await _dbcontext.Mentors.Where(m => m.MentorId == id).Select(m => new Mentor()
                {
                   
                    MentorId = m.MentorId,
                    MentorName = m.MentorName,
                    EmailId = m.EmailId,
                    PhoneNo = m.PhoneNo,
                    Location = m.Location,
                    Password=m.Password,
                    JobRole=m.JobRole

                }
                ).FirstOrDefaultAsync();
                return mentor;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region UpdateMentorDetails
        public async Task<Mentor> UpdateMentorDetails(Mentor mentor)
        {
            try
            {
                var mentor1 = await _dbcontext.Mentors.FirstOrDefaultAsync(m => m.MentorId == mentor.MentorId);
                if (mentor != null)
                {
                    
                    mentor1.MentorId = mentor.MentorId;
                    mentor1.MentorName = mentor.MentorName;
                    mentor1.EmailId = mentor.EmailId;
                    mentor1.PhoneNo = mentor.PhoneNo;
                    mentor1.Location = mentor.Location;
                    mentor1.Password = mentor.Password;
                    mentor1.JobRole = mentor.JobRole;
                    _dbcontext.SaveChanges();
                }
                return mentor1;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region save
        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
        #endregion
    }
}
