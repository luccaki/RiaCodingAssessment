namespace RiaMoneyTransfer.ApplicationCore.Exceptions
{
    public class ExceptionResponse
    {
        public required int StatusCode { get; set; }
        public required string Message { get; set; }
    }
}