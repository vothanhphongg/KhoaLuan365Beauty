using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Bookings
{
    public class Time : AggregateRoot<int>
    {
        public string Times { get; set; }
        public void Update(string? times = null)
        {
            Times = times ?? Times;
        }
    }
}