using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceTracker1.Repository
{
    public class ProgressDescriptionRepository : IProgressDescription<Progress>
    {
        private readonly EPTDBContext context;

        public ProgressDescriptionRepository(EPTDBContext context) => this.context = context;

        public async Task<IEnumerable<Progress>> GetByEmployeeId(int employeeId)
        {
            try
            {
                var record = await context.progresses.Where(e => e.EmployeeId == employeeId).Select(e => new Progress()
                {
                    ProgressId = e.ProgressId,
                    EmployeeId = e.EmployeeId,
                    Date = e.Date,
                    ProgressDescription = e.ProgressDescription,


                }).ToListAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Progress> GetById(int id)
        {
            try
            {
                var record = await context.progresses.Where(e => e.ProgressId == id).Select(e => new Progress()
                {
                    ProgressId = e.ProgressId,
                    Date = e.Date,
                    ProgressDescription = e.ProgressDescription,
                    EmployeeId = e.EmployeeId,

                }).FirstOrDefaultAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<Progress> SaveProgressDescription(Progress entity)
        {
            try
            {
                var p = new Progress()
                {
                    // Id =entity.Id  ,
                    EmployeeId = entity.EmployeeId,

                    Date = entity.Date,

                    ProgressDescription = entity.ProgressDescription,



                };
                context.progresses.Add(p);
                await context.SaveChangesAsync();
                return p;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Progress> UpdateProgressDescription(Progress entity)
        {
            try
            {
                var progress = await context.progresses.FirstOrDefaultAsync(p => p.ProgressId == entity.ProgressId);
                if (progress != null)
                {

                    progress.Date = entity.Date;
                    progress.EmployeeId = entity.EmployeeId;


                    progress.ProgressDescription = entity.ProgressDescription;

                    context.SaveChanges();
                }
                return progress;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
