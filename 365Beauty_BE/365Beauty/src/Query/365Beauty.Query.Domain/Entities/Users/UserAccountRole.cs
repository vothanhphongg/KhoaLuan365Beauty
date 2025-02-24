using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserAccountRole : AggregateRoot<int>
    {
        public int RoleId { get; set; }
    }
}