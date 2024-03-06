using RiaMoneyTransfer.ApplicationCore.Entities;

namespace RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<int> PostAsync(IEnumerable<Customer> customers);
    }
}