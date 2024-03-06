using RiaMoneyTransfer.ApplicationCore.Dto;

namespace RiaMoneyTransfer.ApplicationCore.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto[]> GetAsync();
        Task<CustomerResponseDto> PostAsync(IEnumerable<CustomerDto> customers);
    }
}