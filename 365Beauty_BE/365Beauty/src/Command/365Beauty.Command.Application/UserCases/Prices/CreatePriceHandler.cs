using _365Beauty.Command.Application.Commands.Prices;
using _365Beauty.Command.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Command.Domain.Entities.Prices;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Prices
{
    public class CreatePriceHandler : IRequestHandler<CreatePriceBookingCommand, Result<object>>
    {
        private readonly IPriceRepository priceRepository;

        public CreatePriceHandler(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }
        public async Task<Result<object>> Handle(CreatePriceBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Price
            {
                SalonServiceId = request.SalonServiceId,
                BasePrice = request.BasePrice,
                FinalPrice = request.FinalPrice,
                CreatedDate = DateTime.UtcNow,
                IsActived = StatusActived.Actived,
            };
            using var transaction = await priceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                priceRepository.Add(entity);
                await priceRepository.SaveChangesAsync(cancellationToken);
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
