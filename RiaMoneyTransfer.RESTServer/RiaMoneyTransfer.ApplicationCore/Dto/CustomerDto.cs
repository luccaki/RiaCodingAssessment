namespace RiaMoneyTransfer.ApplicationCore.Dto
{
    public class CustomerDto
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required int Age { get; set; }
        public required long Id { get; set; }
    }
}