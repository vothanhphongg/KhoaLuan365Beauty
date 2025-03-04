using _365Beauty.Command.Application.Commands.Bookings.Times;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Bookings.Times
{
    public class CreateTimeHandler : IRequestHandler<CreateTimeCommand, Result<object>>
    {
        private readonly ITimeRepository bookingTypeRepository;

        public CreateTimeHandler(ITimeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }
        public async Task<Result<object>> Handle(CreateTimeCommand request, CancellationToken cancellationToken)
        {
            Time entity = new Time
            {
                Times = request.Times!
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