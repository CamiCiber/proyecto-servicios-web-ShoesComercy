using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiWorker.Dtos;
using ApiWorker.Models;
using ApiWorker.DbContexts;
using ApiWorker.Repository;

namespace ApiWorker.Repository
{
    public class WorkerSQLRepository : IWorkerRepository
    {
        private AppDbContext appDbContext;

        private IMapper mapper;

        public WorkerSQLRepository(AppDbContext dbContext, IMapper mapper) {
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<WorkerDto>> GetAllWorkers()
        {
            List<Worker> workers = await this.appDbContext.Workers.ToListAsync();
            return mapper.Map<List<WorkerDto>>(workers);
        }
        public async Task<Worker> GetWorkersById(int id)
        {
            var worker = await appDbContext.Workers.Where(worker => worker.WorkerId == id)
                .FirstOrDefaultAsync();
            return worker;
        }
        public async Task<bool> deleteWorkersById(int id)
        {
            try
            {
                Worker worker = await this.appDbContext.Workers
                    .FirstOrDefaultAsync(worker => worker.WorkerId == id);
                if(worker == null)
                {
                    return false;
                }
                appDbContext.Workers.Remove(worker);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<WorkerDto> updateWorkers(WorkerDto workerDto)
        {
            var worker = mapper.Map<Worker>(workerDto);
            this.appDbContext.Update(worker);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<WorkerDto>(worker);
        }
        public async Task<WorkerDto> createWorkers(WorkerDto workerDto)
        {
            var worker = mapper.Map<Worker>(workerDto);
            this.appDbContext.Workers.Add(worker);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<WorkerDto>(worker);
        }

    


    }
}
