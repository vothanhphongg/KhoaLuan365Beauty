using _365Architect.Demo.Query.Domain.Abstractions.Entities;

namespace _365Architect.Demo.Query.Domain.Abstractions.Aggregates
{
    /// <summary>
    /// Aggregate root with custom type of key
    /// </summary>
    /// <typeparam name="TKey">Generic type</typeparam>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}