﻿using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Bookings
{
    public class BookingType : AggregateRoot<int>
    {
        public string Name { get; set; }

        public void Update(string? name = null)
        {
            Name = name ?? Name;
        }
    }
}