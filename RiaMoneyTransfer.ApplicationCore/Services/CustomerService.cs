using RiaMoneyTransfer.ApplicationCore.Dto;
using RiaMoneyTransfer.ApplicationCore.Entities;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Services;

namespace RiaMoneyTransfer.ApplicationCore.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<IEnumerable<CustomerDto>> GetAsync()
        {
            var result = await _customerRepository.GetAsync();
            return result.Select(Map);
        }

        public async Task<int> PostAsync(IEnumerable<CustomerDto> customers)
        {
            return await _customerRepository.PostAsync(customers.Select(Map));
        }

        private CustomerDto Map(Customer customer)
        {
            return new CustomerDto { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Age = customer.Age };
        }

        private Customer Map(CustomerDto customer)
        {
            return new Customer { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Age = customer.Age };
        }
    }
}