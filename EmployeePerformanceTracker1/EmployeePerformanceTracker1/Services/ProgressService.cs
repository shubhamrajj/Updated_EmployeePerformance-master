using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class ProgressService
    {
        IProgressDescription<Progress> _repository;
        public ProgressService(IProgressDescription<Progress> repo)
        {
            _repository = repo;
        }

        #region getprogressbyemployeeid
        public async Task<IEnumerable<Progress>> GetByEmployeeId(int employeeId)
        {
            try
            {
                return await _repository.GetByEmployeeId(employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region getbyid
        public async Task<Progress> GetById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region insert
        public async Task<Progress> SaveProgressDescription(Progress entity)
        {
            try
            {
                return await _repository.SaveProgressDescription(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region update
        public async Task<Progress> UpdateProgressDescription(Progress entity)
        {
            try
            {
                return await _repository.UpdateProgressDescription(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }
    }
}
