﻿using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserBookings
{
    public class UpdateUserBookingCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public int IsActived { get; set; }
    }
}