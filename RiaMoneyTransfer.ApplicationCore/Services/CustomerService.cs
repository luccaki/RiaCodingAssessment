using RiaMoneyTransfer.ApplicationCore.Dto;
using RiaMoneyTransfer.ApplicationCore.Entities;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Services;

namespace RiaMoneyTransfer.ApplicationCore.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<CustomerDto[]> GetAsync()
        {
            var result = await _customerRepository.GetAsync();
            return result.Select(Map).ToArray();
        }

        public async Task<CustomerResponseDto> PostAsync(IEnumerable<CustomerDto> customers)
        {
            var ret = new CustomerResponseDto();
            var currentArray = await GetAsync();

            foreach(var customer in customers)
            {
                if (currentArray.Any(c => c.Id == customer.Id))
                {
                    ret.FailedCustomers.Add(new FailedCustomerDto(customer, $"Id {customer.Id} is already been used!"));
                    continue;
                }

                if (customer.Age < 18)
                {
                    ret.FailedCustomers.Add(new FailedCustomerDto(customer, $"Age must been greater or equal to 18!"));
                    continue;
                }

                currentArray = AddToArray(customer, currentArray);
            }

            await _customerRepository.PostAsync(currentArray.Select(Map).ToArray());

            ret.ArrayLength = currentArray.Length;
            return ret;
        }

        private static CustomerDto[] AddToArray(CustomerDto customer, CustomerDto[] currentArray)
        {
            var ret = new CustomerDto[currentArray.Length + 1];
            int index = 0;

            while (index < currentArray.Length &&
                   (string.Compare(customer.LastName, currentArray[index].LastName, StringComparison.OrdinalIgnoreCase) > 0 ||
                    (string.Compare(customer.LastName, currentArray[index].LastName, StringComparison.OrdinalIgnoreCase) == 0 &&
                     string.Compare(customer.FirstName, currentArray[index].FirstName, StringComparison.OrdinalIgnoreCase) > 0)))
            {
                ret[index] = currentArray[index];
                index++;
            }

            ret[index] = customer;

            while (index < currentArray.Length)
            {
                ret[index + 1] = currentArray[index];
                index++;
            }

            return ret;
        }

        private static CustomerDto Map(Customer customer)
        {
            return new CustomerDto { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Age = customer.Age };
        }

        private static Customer Map(CustomerDto customer)
        {
            return new Customer { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Age = customer.Age };
        }
    }
}