using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonCatalogs
{
    public class LockOrUnLockBeautySalonCatalogHandler : IRequestHandler<LockOrUnLockBeautySalonCatalogCommand, Result<object>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public LockOrUnLockBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<object>> Handle(LockOrUnLockBeautySalonCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await beautySalonCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await beautySalonCatalogRepository.FindByIdAsync(request.Id);

                entity.IsActived = entity.IsActived == StatusActived.UnActived ? StatusActived.Actived : StatusActived.UnActived;
                beautySalonCatalogRepository.Update(entity);
                await beautySalonCatalogRepository.SaveChangesAsync(cancellationToken);
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