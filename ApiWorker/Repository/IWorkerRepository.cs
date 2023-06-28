using ApiWorker.Dtos;
using ApiWorker.Models;

namespace ApiWorker.Repository
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<WorkerDto>> GetAllWorkers();
        Task<Worker> GetWorkersById(int id);
        Task<WorkerDto> createWorkers(WorkerDto workerDto);
        Task<bool> deleteWorkersById(int id);
        Task<WorkerDto> updateWorkers(WorkerDto workerDto);
   
    }
}
