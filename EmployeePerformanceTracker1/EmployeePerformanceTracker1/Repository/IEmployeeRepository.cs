namespace EmployeePerformanceTracker1.Repository
{
    public interface IEmployeeRepository<TEntity> where TEntity : class
    {
        #region abstract methods
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        //Task<TEntity> GetByEmployeeId(int EmpId);
        Task<IEnumerable<TEntity>> GetByMentorId(int MentorId);
        Task<TEntity> SaveRecord(TEntity entity);
        Task<TEntity> UpdateRecord(TEntity entity);

        Task Save();

        #endregion
    }
}
