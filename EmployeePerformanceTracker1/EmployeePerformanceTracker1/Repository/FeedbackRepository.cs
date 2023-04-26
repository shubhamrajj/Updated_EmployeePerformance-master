using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeePerformanceTracker1.Repository
{
    public class FeedbackRepository:IFeedbackRepository<Feedback>
    {
        private readonly EPTDBContext _context;
        public FeedbackRepository(EPTDBContext context)
        {
            _context = context;
        }

        #region InsertFeedback
        public async Task<Feedback> Insert(Feedback entity)
        {
            try
            {
                var feedback = new Feedback()
                {
                    FeedbackId = entity.FeedbackId,
                    Rating = entity.Rating,
                    Comment = entity.Comment,
                    EmployeeId = entity.EmployeeId,
                    ProgressId = entity.ProgressId
                };
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region updateFeedback
        public async Task<Feedback> Update(Feedback entity)
        {
            try
            {
                var feedback=await _context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == entity.FeedbackId);
                if (feedback != null)
                {
                    feedback.FeedbackId = entity.FeedbackId;
                    feedback.Rating = entity.Rating;
                    feedback.Comment = entity.Comment;
                    feedback.EmployeeId = entity.EmployeeId;
                    feedback.ProgressId = entity.ProgressId;

                    _context.SaveChanges();
                }
                return feedback;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
