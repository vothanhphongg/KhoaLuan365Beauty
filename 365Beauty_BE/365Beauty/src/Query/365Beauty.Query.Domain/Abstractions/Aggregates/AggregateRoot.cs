using _365Beauty.Query.Domain.Abstractions.Entities;

namespace _365Beauty.Query.Domain.Abstractions.Aggregates
{
    /// <summary>
    /// Aggregate root
    /// </summary>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}