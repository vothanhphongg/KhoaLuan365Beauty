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
    public class UpdatePriceAndBookingHandler : IRequestHandler<UpdatePriceAndBookingCommand, Result<object>>
    {
        private readonly IPriceRepository priceRepository;
        private readonly IBookingRepository bookingRepository;

        public UpdatePriceAndBookingHandler(IPriceRepository priceRepository, IBookingRepository bookingRepository)
        {
            this.priceRepository = priceRepository;
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result<object>> Handle(UpdatePriceAndBookingCommand request, CancellationToken cancellationToken)
        {
            var price = await priceRepository.FindSingleAsync(true, true, x => x.SalonServiceId == request.SalonServiceId && x.IsActived == StatusActived.Actived);
            price.IsActived = StatusActived.UnActived;
            price.EndDate = DateTime.UtcNow;
            var entity = new Price
            {
                SalonServiceId = request.SalonServiceId,
                BasePrice = request.BasePrice,
                FinalPrice = request.FinalPrice,
                CreatedDate = DateTime.UtcNow,
                IsActived = StatusActived.Actived,
            };
            var booking = await bookingRepository.FindSingleAsync(true, true, x => x.SalonServiceId == request.SalonServiceId, cancellationToken, x => x.BookingTimes);

            booking.BookingTimes = request.BookingTimes?.Distinct().Select(time => new BookingTimes
            {
                BookingId = booking.Id,
                TimeId = time

            }).ToList() ?? booking.BookingTimes;
            booking.Count = request.BookingCount ?? booking.Count;
            using var transaction = await priceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                priceRepository.Update(price);
                await priceRepository.SaveChangesAsync(cancellationToken);
                priceRepository.Add(entity);
                await priceRepository.SaveChangesAsync(cancellationToken);
                bookingRepository.Update(booking);
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
