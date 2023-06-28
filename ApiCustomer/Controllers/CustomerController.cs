using Microsoft.AspNetCore.Mvc;
using AppCustomer.Dtos;
using AppCustomer.Repository;

namespace CustomerApp.Controllers
{
    [Route("api/customer/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository customerRepository;

        private ResponseDto responseDto;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            this.responseDto = new ResponseDto();
        }


        [HttpGet]
        [Route("/GetCustomer")]
        public async Task<object> GetCustomers()
        {
            try
            {
                IEnumerable<CustomerDto> categoryDtos = await customerRepository.GetAllCustomers();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = categoryDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpGet]
        [Route("/GetCustomer/{id}")]
        public async Task<object> getCustomerById(int id)
        {
            return await customerRepository.GetCustomersById(id);
        }


        [HttpPost]
        [Route("/InsertCustomer")]
        public async Task<object> createCustomer(CustomerDto customerDto)
        {
            try
            {
                CustomerDto result = await customerRepository.createCustomers(customerDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpPut]
        [Route("/UpdateCustomer")]
        public async Task<object> updateCustomers(CustomerDto customerDto)
        {
            try
            {
                CustomerDto result = await customerRepository.updateCustomers(customerDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpDelete]
        [Route("/DeleteCustomer/{id}")]
        public async Task<object> deleteCustomer(int id)
        {
            try
            {
                bool result = await customerRepository.deleteCustomersById(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
    }
}
