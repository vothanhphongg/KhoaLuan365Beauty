namespace _365Beauty.Query.Application.DTOs.BeautySalons
{
    public class BeautySalonServiceFullDTO
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public Decimal? BasePrice { get; set; }
        public Decimal? FinalPrice { get; set; }
        public int PrecentDiscount { get; set; }
        public string SerName { get; set; }
        public string SlnName { get; set; }
        public string? AddressFullAscending { get; set; }
        public string SlnImage { get; set; }
    }
}
