using RiaMoneyTransfer.ApplicationCore.Dto;

namespace RiaMoneyTransfer.ApplicationCore.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAsync();
        Task<int> PostAsync(IEnumerable<CustomerDto> customers);
    }
}