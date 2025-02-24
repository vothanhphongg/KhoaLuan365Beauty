using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.BeautySalons
{
    public class BeautySalonCatalog : AggregateRoot<int>
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Tel { get; set; }
        public string Image { get; set; }
        public string? WorkingDate { get; set; }
        public string? Address { get; set; }
        public string? WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserIdCreated { get; set; }
        public int? UserIdUpdated { get; set; }
        public int IsActived { get; set; }
        public List<BeautySalonService>? BeautySalonServices { get; set; }
    }
}