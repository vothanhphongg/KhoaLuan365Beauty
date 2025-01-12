namespace _365Architect.Demo.Query.Contract.DTOs
{
    /// <summary>
    /// DTO of order item, contain price, quantity and sample id
    /// </summary>
    public class OrderItemDTO
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SampleId { get; set; }
    }
}