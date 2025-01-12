using _365Architect.Demo.Query.Domain.Abstractions.Aggregates;

namespace _365Architect.Demo.Query.Domain.Entities
{
    /// <summary>
    /// A domain aggregate root with int key type
    /// </summary>
    public class Order : AggregateRoot<int>
    {
        private readonly List<OrderItem> orderItems;

        /// <summary>
        /// Date order being created
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Items of order
        /// </summary>
        public virtual IEnumerable<OrderItem> OrderItems => orderItems.AsReadOnly();

        private Order()
        {
            orderItems = new List<OrderItem>();
            OrderDate = DateTime.Now;
        }

        private Order(List<OrderItem> items)
        {
            OrderDate = DateTime.Now;
            orderItems = items;
        }

        /// <summary>
        /// Try to create order
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Order TryCreate(List<OrderItem>? items = null)
        {
            return items is null ? new Order() : new Order(items);
        }

        /// <summary>
        /// Add an item into order
        /// </summary>
        /// <param name="item">Order item</param>
        public void AddOrderItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        /// <summary>
        /// Remove an item out of order
        /// </summary>
        /// <param name="item">Order item</param>
        public void RemoveOrderItem(OrderItem item)
        {
            orderItems.Remove(item);
        }

        /// <summary>
        /// Calculate total order price
        /// </summary>
        /// <returns>Total price of order</returns>
        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            orderItems.ForEach(x => totalPrice += x.TotalPrice);
            return totalPrice;
        }
    }
}