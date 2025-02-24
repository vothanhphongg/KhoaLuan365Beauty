using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Times
{
    public class Time : AggregateRoot<int>
    {
        public int Times { get; set; }
    }
}