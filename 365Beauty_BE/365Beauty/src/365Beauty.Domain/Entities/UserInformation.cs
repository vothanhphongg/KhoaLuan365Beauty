using _365Beauty.Domain.Abstractions.Aggregates;

namespace _365Beauty.Domain.Entities
{
    public class UserInformation : AggregateRoot<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Img { get; set; }
        public string? IdCard { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
        public UserAccount? userAccount { get; set; }
    }
}