using _365Architect.Demo.Query.Domain.Abstractions.Entities;
using _365Architect.Demo.Query.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace _365Architect.Demo.Query.Domain.Entities
{
    /// <summary>
    /// Item of order with int key type. Contain price, quantity, total price of sample
    /// </summary>
    public class OrderItem : Entity<int>
    {
        /// <summary>
        /// Price of item
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Quantity of item
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Total price of item, can be calculated by multiply price with quantity
        /// </summary>
        public double TotalPrice { get; private set; }

        /// <summary>
        /// Id of sample
        /// </summary>
        public int SampleId { get; private set; }

        /// <summary>
        /// Main of item
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// Indicate which order this item attached to
        /// </summary>
        [JsonIgnore]
        public Order Order { get; set; }

        private OrderItem()
        {
        }

        private OrderItem(double price, int quantity, int sampleId, Order order)
        {
            Price = price;
            Quantity = quantity;
            TotalPrice = price * quantity;
            SampleId = sampleId;
            Order = order;
        }

        /// <summary>
        /// Try to create order item. If it can't create order item, throw validation exception
        /// </summary>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="sampleId"></param>
        /// <param name="order"></param>
        /// <returns>The created order item</returns>
        /// <exception cref="ValidationException"></exception>
        public static OrderItem TryCreate(double price, int quantity, int sampleId, Order order)
        {
            // Initialize a list to collect validation errors
            var errors = new List<string>();
            // Validate quantity is not less than 1
            if (quantity < 1)
            {
                errors.Add(MessageConstant.NotLowerThan<OrderItem>(x => x.Quantity, 1));
            }

            // Validate price is greater than 0
            if (price <= 0)
            {
                errors.Add(MessageConstant.NotLowerThanOrEqual<OrderItem>(x => x.Price, 0));
            }

            // If there are validation errors, throw a ValidationException
            if (errors.Any())
            {
                throw new ValidationException(errors.ToArray());
            }

            // Create a new OrderItem
            var orderItem = new OrderItem(price, quantity, sampleId, order);
            return orderItem;
        }
    }
}