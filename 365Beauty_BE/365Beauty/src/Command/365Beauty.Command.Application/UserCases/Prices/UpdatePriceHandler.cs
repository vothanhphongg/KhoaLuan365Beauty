using _365Beauty.Command.Application.Commands.Prices;
using _365Beauty.Command.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Command.Domain.Entities.Prices;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Prices
{
    public class UpdatePriceHandler : IRequestHandler<UpdatePriceCommand, Result<object>>
    {
        private readonly IPriceRepository priceRepository;

        public UpdatePriceHandler(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }
        public async Task<Result<object>> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var price = await priceRepository.FindSingleAsync(false, true, x => x.SalonServiceId == request.SalonServiceId);
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
            using var transaction = await priceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                priceRepository.Update(price);
                await priceRepository.SaveChangesAsync(cancellationToken);
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
