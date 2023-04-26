using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class FeedbackService
    {
        IFeedbackRepository<Feedback> repository;
        public FeedbackService(IFeedbackRepository<Feedback> repository)
        {
            this.repository = repository;
        }

        #region insertfeedback
        public async Task<Feedback> Insert(Feedback entity)
        {
            return await repository.Insert(entity);
        }
        #endregion

        #region updatefeedback
        public async Task<Feedback> Update(Feedback entity)
        {
            return await repository.Update(entity);
        }
        #endregion

        #region save
        public async Task Save()
        {
            await repository.Save();
        }
        #endregion

    }
}
