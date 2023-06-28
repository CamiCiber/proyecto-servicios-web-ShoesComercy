using ApiWorker.Models;
using ApiWorker.Repository;
using ApiWorker.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiWorker.Controllers
{
    [Route("api/worker/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private IWorkerRepository workerRepository;

        private ResponseDto responseDto;

        public WorkerController(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
            responseDto = new ResponseDto();
        }

        [HttpGet]
        [Route("/getAll")]
        public async Task<object> GetWorkers()
        {
            try
            {
                IEnumerable<WorkerDto> workerDtos = await workerRepository.GetAllWorkers();
                responseDto.IsSucceed = true;
                responseDto.Result = workerDtos;
                responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpGet]
        [Route("/GetWorkers/{id}")]
        public async Task<object> getWorkerById(int id)
        {
            return await workerRepository.GetWorkersById(id);
        }

        [HttpPost]
        [Route("/insert")]
        public async Task<object> Post(WorkerDto workerDto)
        {
            try
            {
                WorkerDto result = await workerRepository.createWorkers(workerDto);
                responseDto.IsSucceed = true;
                responseDto.Result = result;
                responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpPut]
        [Route("/update")]
        public async Task<object> updateWorkers(WorkerDto workerDto)
        {
            try
            {
                WorkerDto result = await workerRepository.updateWorkers(workerDto);
                responseDto.IsSucceed = true;
                responseDto.Result = result;
            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<object> deleteWroker(int id)
        {
            try
            {
                bool result = await workerRepository.deleteWorkersById(id);
                responseDto.IsSucceed = true;
                responseDto.Result = result;
                responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
    }
}
