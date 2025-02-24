using _365Beauty.Command.Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Beauty.Command.Domain.Entities.Prices
{
    public class Price : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public Decimal BasePrice { get; set; }
        public Decimal FinalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActived { get; set; }
    }
}
