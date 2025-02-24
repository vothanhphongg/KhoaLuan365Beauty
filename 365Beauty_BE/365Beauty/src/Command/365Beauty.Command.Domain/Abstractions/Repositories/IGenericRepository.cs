﻿using _365Beauty.Command.Domain.Abstractions.Entities;
using _365Beauty.Contract.DependencyInjection.Options;
using System.Data;
using System.Linq.Expressions;

namespace _365Beauty.Command.Domain.Abstractions.Repositories
{
    /// <summary>
    /// Provide generic repository
    /// </summary>
    /// <typeparam name="TEntity">Generic type of domain entity</typeparam>
    /// <typeparam name="TKey">Generic key of domain entity</typeparam>
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        /// <summary>
        /// Find domain entity by id. Returned entity can be tracking
        /// </summary>
        /// <param name="id">ID of domain entity</param>
        /// <param name="isTracking">Tracking state of entity</param>
        /// <param name="allowNullReturn">Allow null return. If false, when value is null will throw not found exception</param>
        /// <param name="cancellationToken"></param>
        /// <param name="includeProperties">Include any relationship if needed</param>
        /// <returns>Domain entity with given id or null if entity with given id not found</returns>
        Task<TEntity?> FindByIdAsync(TKey id,
                                     bool isTracking = false,
                                     bool allowNullReturn = true,
                                     CancellationToken cancellationToken = default,
                                     params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Find entity by id. Returned entity can be tracking
        /// </summary>
        /// <param name="id">ID of domain entity</param>
        /// <param name="option">Option to find entity</param>
        /// <param name="cancellationToken"></param>
        /// <param name="includeProperties">Include any relationship if needed</param>
        /// <returns>Domain entity with given id or null if entity with given id not found</returns>
        Task<TEntity?> FindByIdAsync(TKey id,
                                     FindOption option,
                                     CancellationToken cancellationToken = default,
                                     params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Find single entity that satisfied predicate expression. Can be tracking
        /// </summary>
        /// <param name="isTracking">Tracking state of entity</param>
        /// <param name="allowNullReturn">Allow null return. If false, when value is null will throw not found exception</param>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="cancellationToken"></param>
        /// <param name="includeProperties">Include any relationship if needed</param>
        /// <returns>Domain entity matched expression or null if entity not found</returns>
        Task<TEntity?> FindSingleAsync(bool isTracking = false,
                                       bool allowNullReturn = true,
                                       Expression<Func<TEntity, bool>>? predicate = null,
                                       CancellationToken cancellationToken = default,
                                       params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Check entity with specific predicate is exist in current application
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if entity exist, otherwise false</returns>
        Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Find all entity that satisfied predicate expression. Can be tracking
        /// </summary>
        /// <param name="isTracking">Tracking state of entity</param>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="includeProperties">Include any relationship if needed</param>
        /// <returns>IQueryable of entities that match predicate expression</returns>
        IQueryable<TEntity> FindAll(bool isTracking = false, Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Marked entity as Added state
        /// </summary>
        /// <param name="entity">Added entity</param>
        void Add(TEntity entity);

        /// <summary>
        /// Marked entity as Updated state
        /// </summary>
        /// <param name="entity">Updated entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Marked multiple entities as Creates state
        /// </summary>
        /// <param name="entities">Add entities</param>
        void AddMultiple(List<TEntity> entities);

        /// <summary>
        /// Marked entity as Deleted state
        /// </summary>
        /// <param name="entity">Removed entity</param>
        /// 
        void Remove(TEntity entity);

        /// <summary>
        /// Marked multiple entities as Deleted state
        /// </summary>
        /// <param name="entities">Removed entities</param>
        void RemoveMultiple(List<TEntity> entities);

        /// <summary>
        /// Apply all changes in context to database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Number of changes are made to database</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Begin a transaction
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Database transaction, can be commited and rollback</returns>
        Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}