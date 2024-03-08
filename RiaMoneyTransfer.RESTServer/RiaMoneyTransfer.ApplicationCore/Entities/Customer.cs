namespace RiaMoneyTransfer.ApplicationCore.Entities
{
    public class Customer
    {
        public required long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Age { get; set; }
    }
}