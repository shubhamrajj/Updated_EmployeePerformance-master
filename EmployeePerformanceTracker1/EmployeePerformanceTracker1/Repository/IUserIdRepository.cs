namespace EmployeePerformanceTracker1.Repository
{
    public interface IUserIdRepository<TKey>
    {
        Task<int> GetEmployeeId(string item);
        Task<int> GetAdminId(string item);
        Task<int> GetMentorId(string item);
    }
}
