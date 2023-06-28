using AppCustomer.DbContexts;
using AppCustomer.Dtos;
using AppCustomer.Models;
using AppCustomer.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Repository
{
    public class CustomerSQLRepository:ICustomerRepository
    {
        private AppDbContext appDbContext;

        private IMapper mapper;

        public CustomerSQLRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task<bool> deleteCustomersById(int id)
        {
            try
            {
                Customer customer = await this.appDbContext.Customers
                    .FirstOrDefaultAsync(customer => customer.CustomerId == id);
                if (customer == null)
                {
                    return false;
                }
                appDbContext.Customers.Remove(customer);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CustomerDto> updateCustomers(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            this.appDbContext.Update(customer);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<CustomerDto>(customer);
        }
        public async Task<CustomerDto> createCustomers(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            this.appDbContext.Customers.Add(customer);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<Customer> GetCustomersById(int id)
        {
            var customer = await appDbContext.Customers.Where(customer => customer.CustomerId == id)
                .FirstOrDefaultAsync();
            return customer;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            List<Customer> customer = await this.appDbContext.Customers.ToListAsync();
            return mapper.Map<List<CustomerDto>>(customer);
        }
    }
}
