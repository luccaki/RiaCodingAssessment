namespace RiaMoneyTransfer.ApplicationCore.Dto
{
    public class CustomerResponseDto
    {
        public int ArrayLength { get; set; }
        public IList<FailedCustomerDto> FailedCustomers { get; set; } = [];
    }

    public class FailedCustomerDto(CustomerDto customer, string error)
    {
        public CustomerDto FailedCustomer { get; set; } = customer;
        public string Error { get; set; } = error;
    }
}