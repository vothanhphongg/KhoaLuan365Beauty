using _365Beauty.Command.Application.Commands.BeautySalons.PriceAndBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.BeautySalons;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.PriceAndBookings
{
    public class CreatePriceAndBookingHandler : IRequestHandler<CreatePriceAndBookingCommand, Result<object>>
    {
        private readonly IPriceRepository priceRepository;
        private readonly IBookingRepository bookingRepository;

        public CreatePriceAndBookingHandler(IPriceRepository priceRepository, IBookingRepository bookingRepository)
        {
            this.priceRepository = priceRepository;
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result<object>> Handle(CreatePriceAndBookingCommand request, CancellationToken cancellationToken)
        {
            Price price = new Price
            {
                SalonServiceId = request.SalonServiceId,
                BasePrice = request.BasePrice,
                FinalPrice = request.FinalPrice,
                CreatedDate = DateTime.UtcNow,
                IsActived = StatusActived.Actived,
            };
            Booking booking = new Booking
            {
                SalonServiceId = request.SalonServiceId,
                Count = request.BookingCount
            };
            booking.BookingTimes = request.BookingTimes?.Distinct().Select(time => new BookingTimes
            {
                TimeId = time
            }).ToList();
            using var transaction = await priceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                priceRepository.Add(price);
                await priceRepository.SaveChangesAsync(cancellationToken);
                bookingRepository.Add(booking);
                await bookingRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();
                throw;
            }
        }
    }
}
