namespace _365Beauty.Query.Application.DTOs.BeautySalons
{
    public class BeautySalonServiceWithPriceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public Decimal? BasePrice { get; set; }
        public Decimal? FinalPrice { get; set; }
        public int PrecentDiscount { get; set; }
    }
}