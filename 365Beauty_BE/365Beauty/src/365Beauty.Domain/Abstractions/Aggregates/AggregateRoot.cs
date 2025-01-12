using _365Beauty.Domain.Abstractions.Entities;

namespace _365Beauty.Domain.Abstractions.Aggregates
{
    /// <summary>
    /// Aggregate root
    /// </summary>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}