using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.BeautySalons
{
    public class BeautySalonService : AggregateRoot<int>
    {
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActived { get; set; }
        public Price? Price { get; set; }
        public void Update(int? serviceId = null, string ? name = null, string? description = null, string? image = null)
        {
            ServiceId = serviceId ?? ServiceId;
            Name = name ?? Name;
            Description = description ?? Description;
            Image = image ?? Image;
        }
    }
}