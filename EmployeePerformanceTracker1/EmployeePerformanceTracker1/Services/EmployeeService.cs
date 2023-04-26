using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class EmployeeService
    {
        IEmployeeRepository<Employee> _repository;
        public EmployeeService(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        #region getall
        
        public async Task<IEnumerable<Employee>> GetAll()
        {
          return await _repository.GetAll();
        }



        #endregion

        #region getbyid
        public async Task<Employee> GetById(int id)
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

        #region getbymentorid
        public async Task<IEnumerable<Employee>> GetByMentorId(int MentorId)
        {
            try
            {
                return await _repository.GetByMentorId(MentorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region insert
        public async Task<Employee> SaveRecord(Employee entity)
        {
            try
            {
                return await _repository.SaveRecord(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region update
        public async Task<Employee> UpdateRecord(Employee entity)
        {
            try
            {
                return await _repository.UpdateRecord(entity);
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
