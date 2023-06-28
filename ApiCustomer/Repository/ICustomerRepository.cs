using AppCustomer.Dtos;
using AppCustomer.Models;

namespace AppCustomer.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> createCustomers(CustomerDto customerDto);
        Task<bool> deleteCustomersById(int id);
        Task<CustomerDto> updateCustomers(CustomerDto customersDto);
        Task<Customer> GetCustomersById(int id);
    }
}
