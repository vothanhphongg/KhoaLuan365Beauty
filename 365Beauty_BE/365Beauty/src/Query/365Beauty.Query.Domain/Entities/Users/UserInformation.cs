﻿using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserInformation : AggregateRoot<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Img { get; set; }
        public string? IdCard { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? WardId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
    }
}