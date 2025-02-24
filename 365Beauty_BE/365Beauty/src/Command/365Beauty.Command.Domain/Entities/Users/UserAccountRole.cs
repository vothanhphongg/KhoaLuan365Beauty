using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Users
{
    public class UserAccountRole : AggregateRoot<int>
    {
        public int RoleId { get; set; }
    }
}