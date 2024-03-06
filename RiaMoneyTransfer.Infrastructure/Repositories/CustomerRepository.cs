using RiaMoneyTransfer.ApplicationCore.Entities;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure;

namespace RiaMoneyTransfer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return new List<Customer>()
            {
                new() { Id = 1, FirstName = "Lucca", LastName = "Ianaguivara", Age = 24},
                new() { Id = 2, FirstName = "Ianaguivara", LastName = "Lucca", Age = 42}
            };
        }

        public async Task<int> PostAsync(IEnumerable<Customer> customers)
        {
            if (customers.Count() > 1)
                throw new ArgumentException("Can't process two customers");
            return 1;
        }
    }
}