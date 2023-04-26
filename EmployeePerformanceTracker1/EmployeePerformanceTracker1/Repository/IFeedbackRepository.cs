namespace EmployeePerformanceTracker1.Repository
{
    public interface IFeedbackRepository<T1> where T1 : class
    {
        Task<T1> Insert(T1 tentity);
        Task<T1> Update(T1 tentity);

        Task Save();

    }
}
