using _365Beauty.Command.Application.Commands.Bookings.BookingTypes;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Bookings.BookingTypes
{
    public class DeleteBookingTypeHandler : IRequestHandler<DeleteBookingTypeCommand, Result<object>>
    {
        private readonly IBookingTypeRepository bookingTypeRepository;

        public DeleteBookingTypeHandler(IBookingTypeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }
        public async Task<Result<object>> Handle(DeleteBookingTypeCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await bookingTypeRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                BookingType? entity = await bookingTypeRepository.FindByIdAsync(request.Id);

                bookingTypeRepository.Remove(entity!);
                await bookingTypeRepository.SaveChangesAsync(cancellationToken);
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