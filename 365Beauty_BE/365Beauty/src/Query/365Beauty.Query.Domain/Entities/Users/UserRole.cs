using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserRole : AggregateRoot<int>
    {
        public string Name { get; set; }
    }
}