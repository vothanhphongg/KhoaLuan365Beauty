using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserRating : AggregateRoot<int>
    {
        public int UserId { get; set; }
        public int SalonServiceId { get; set; }
        public string? Comment { get; set; }
        public double Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserInformation? UserInformation { get; set; }
    }
}