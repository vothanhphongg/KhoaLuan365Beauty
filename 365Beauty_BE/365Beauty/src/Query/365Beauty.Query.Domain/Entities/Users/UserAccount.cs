using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserAccount : AggregateRoot<int>
    {
        public string Tel { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Type { get; set; }
        public string Otp { get; set; }
        public int IsActived { get; set; }
        public UserInformation? UserInformation { get; set; }
        public List<UserAccountRole> UserAccountRoles { get; set; }
    }
}