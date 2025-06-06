﻿using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.Bookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.Bookings
{
    public class GetAllBookingTimesByDateHandler : IRequestHandler<GetAllBookingTimesByDateQuery, Result<List<Time>>>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IUserBookingRepository userBookingRepository;

        public GetAllBookingTimesByDateHandler(IBookingRepository bookingRepository, IUserBookingRepository userBookingRepository)
        {
            this.bookingRepository = bookingRepository;
            this.userBookingRepository = userBookingRepository;
        }
        public async Task<Result<List<Time>>> Handle(GetAllBookingTimesByDateQuery request, CancellationToken cancellationToken)
        {
            var userBooking = userBookingRepository.FindAll(false, x => x.SalonServiceId == request.SalonServiceId && x.BookingDate == request.BookingDate && x.IsActived != UserBookingConst.CANCEL, x => x.Time!).ToList();

            var booking = await bookingRepository.FindSingleAsync(false, true, x => x.SalonServiceId == request.SalonServiceId, cancellationToken, x => x.Times!);
            if (booking == null)
            {
                return Result.Ok(new List<Time>());
            }
            var entity = booking.Times.Where(x => userBooking.Count(userbook => userbook.Time != null && userbook.Time.Id == x.Id) < booking.Count).ToList();

            return Result.Ok(entity);
        }
    }
}