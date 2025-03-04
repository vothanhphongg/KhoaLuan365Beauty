using _365Beauty.Command.Application.Commands.Bookings.BookingTypes;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Bookings.BookingTypes
{
    public class CreateBookingTypeHandler : IRequestHandler<CreateBookingTypeCommand, Result<object>>
    {
        private readonly IBookingTypeRepository bookingTypeRepository;

        public CreateBookingTypeHandler(IBookingTypeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }
        public async Task<Result<object>> Handle(CreateBookingTypeCommand request, CancellationToken cancellationToken)
        {
            BookingType entity = new BookingType
            {
                Name = request.Name!
            };
            using var transaction = await bookingTypeRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                bookingTypeRepository.Add(entity);
                await bookingTypeRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}