using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Users
{
    public class UserRole : AggregateRoot<int>
    {
        public string Name { get; set; }
    }
}