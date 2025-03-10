namespace _365Beauty.Contract.Helpers
{
    public class VnpayResult
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public string PaymentId { get; set; }
    }
}