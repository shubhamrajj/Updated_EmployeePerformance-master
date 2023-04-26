namespace EmployeePerformanceTracker1.Repository
{
    public interface IProgressDescription<TEntity> where TEntity : class
    {
        #region abstract methods
        Task<TEntity> SaveProgressDescription(TEntity entity);
        Task<TEntity> UpdateProgressDescription(TEntity entity);

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetByEmployeeId(int MentorId);

        Task Save();

        #endregion
    }
}
