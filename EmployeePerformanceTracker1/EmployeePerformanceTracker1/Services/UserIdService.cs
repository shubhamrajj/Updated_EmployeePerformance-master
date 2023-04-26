using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class UserIdService
    {
        IUserIdRepository<int> _repo;
        public UserIdService(IUserIdRepository<int> repo)
        {
            _repo = repo;
        }
        #region adminid
        public async Task<int> GetAdminId(string item)
        {
            return await _repo.GetAdminId(item);
        }
        #endregion

        #region employeeid
        public async Task<int> GetEmployeeId(string item)
        {
            return await _repo.GetEmployeeId(item);
        }
        #endregion

        #region mentorid
        public async Task<int> GetMentorId(string item)
        {
            return await _repo.GetMentorId(item);
        }
        #endregion
    }
}
