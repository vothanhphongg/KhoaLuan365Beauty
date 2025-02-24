using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.StaffCatalogs
{
    public class ActiveStaffCatalogHanler : IRequestHandler<ActiveStaffCatalogCommand, Result<object>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public ActiveStaffCatalogHanler(IStaffCatalogRepository staffCatalogRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
        }

        public async Task<Result<object>> Handle(ActiveStaffCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await staffCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                StaffCatalog? entity = await staffCatalogRepository.FindByIdAsync(request.Id);
                
                entity.IsActived = 1;
                staffCatalogRepository.Update(entity!);
                await staffCatalogRepository.SaveChangesAsync(cancellationToken);

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