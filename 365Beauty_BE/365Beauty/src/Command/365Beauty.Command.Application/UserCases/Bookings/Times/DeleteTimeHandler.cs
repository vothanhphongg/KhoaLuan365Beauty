using _365Beauty.Command.Application.Commands.Bookings.Times;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Bookings.Times
{
    public class DeleteTimeHandler : IRequestHandler<DeleteTimeCommand, Result<object>>
    {
        private readonly ITimeRepository bookingTypeRepository;

        public DeleteTimeHandler(ITimeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }
        public async Task<Result<object>> Handle(DeleteTimeCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await bookingTypeRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                Time? entity = await bookingTypeRepository.FindByIdAsync(request.Id);

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