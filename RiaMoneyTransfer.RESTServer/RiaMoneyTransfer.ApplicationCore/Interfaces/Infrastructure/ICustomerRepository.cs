using RiaMoneyTransfer.ApplicationCore.Entities;

namespace RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<Customer[]> GetAsync();
        Task PostAsync(Customer[] customers);
    }
}