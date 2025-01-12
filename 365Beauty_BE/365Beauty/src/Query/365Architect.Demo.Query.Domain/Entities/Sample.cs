using _365Architect.Demo.Query.Domain.Abstractions.Aggregates;
using _365Architect.Demo.Query.Domain.Exceptions;

namespace _365Architect.Demo.Query.Domain.Entities
{
    /// <summary>
    /// Domain entity with int key type
    /// </summary>
    public class Sample : AggregateRoot<int>
    {
        /// <summary>
        /// Title of sample
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of sample
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Due date of sample
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Time sample created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last time sample updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        private Sample(string title, DateTime dueDate, DateTime createdAt, string? description)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Try to create sample. If it can't create sample, throw validation exception
        /// </summary>
        /// <param name="title"></param>
        /// <param name="dueDate"></param>
        /// <param name="description"></param>
        /// <returns>The created sample</returns>
        /// <exception cref="ValidationException"></exception>
        public static Sample TryCreate(string title, DateTime dueDate, string? description)
        {
            // Initialize a list to collect validation errors
            var errors = new List<string>();
            // Get the current date and time
            var createdAt = DateTime.Now;
            // Validate title is not null or empty
            if (string.IsNullOrEmpty(title))
            {
                errors.Add(MessageConstant.NotNullOrEmpty<Sample>(x => x.Title));
            }

            // Validate due date is at least 7 days from the current date
            if (dueDate < createdAt.AddDays(7))
            {
                errors.Add(MessageConstant.NotLessThan<Sample>(x => x.DueDate, "7 days from created date"));
            }

            // If there are validation errors, throw a ValidationException
            if (errors.Any())
            {
                throw new ValidationException(errors.ToArray());
            }

            // Create a new Sample
            var sample = new Sample(title, dueDate, createdAt, description);
            return sample;
        }
    }
}