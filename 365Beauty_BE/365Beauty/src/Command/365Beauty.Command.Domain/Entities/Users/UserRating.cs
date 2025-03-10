using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Users
{
    public class UserRating : AggregateRoot<int>
    {
        public int UserId { get; set; }
        public int SalonServiceId { get; set; }
        public string? Comment { get; set; }
        public double Count { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}