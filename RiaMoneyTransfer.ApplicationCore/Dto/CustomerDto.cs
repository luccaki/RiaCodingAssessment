namespace RiaMoneyTransfer.ApplicationCore.Dto
{
    public class CustomerDto
    {
        public required long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Age { get; set; }
    }
}