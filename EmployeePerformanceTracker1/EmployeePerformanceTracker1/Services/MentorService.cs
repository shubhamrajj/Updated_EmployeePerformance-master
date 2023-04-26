using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;


namespace EmployeePerformanceTracker1.Services
{
    public class MentorService
    {
        IMentorRepository<Mentor> _repository;
        public MentorService(IMentorRepository<Mentor> repository)
        {
            _repository = repository;
        }

        #region mentordetailsbyid
        public async Task<Mentor> GetMentorDetailsById(int id)
        {
            return await _repository.GetMentorDetailsById(id);
        }
        #endregion

        #region updatementordetails
        public async Task UpdateMentorDetails(Mentor entity)
        {
            await _repository.UpdateMentorDetails(entity);
        }
        #endregion

        #region save
        public async Task Save()
        {
            await _repository.Save();
        }
        #endregion
    }
}
