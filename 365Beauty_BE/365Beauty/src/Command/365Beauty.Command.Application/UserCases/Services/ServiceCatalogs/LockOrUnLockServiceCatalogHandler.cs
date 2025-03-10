using _365Beauty.Command.Application.Commands.Services;
using _365Beauty.Command.Domain.Abstractions.Repositories.Services;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Services.ServiceCatalogs
{
    public class LockOrUnLockServiceCatalogHandler : IRequestHandler<LockOrUnLockServiceCatalogCommand, Result<object>>
    {
        private readonly IServiceCatalogRepository serviceCategoryRepository;

        public LockOrUnLockServiceCatalogHandler(IServiceCatalogRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }
        public async Task<Result<object>> Handle(LockOrUnLockServiceCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await serviceCategoryRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await serviceCategoryRepository.FindByIdAsync((int)request.Id!);
                entity.IsActived = entity.IsActived == StatusActived.UnActived ? StatusActived.Actived : StatusActived.UnActived;
                serviceCategoryRepository.Update(entity);
                await serviceCategoryRepository.SaveChangesAsync(cancellationToken);
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