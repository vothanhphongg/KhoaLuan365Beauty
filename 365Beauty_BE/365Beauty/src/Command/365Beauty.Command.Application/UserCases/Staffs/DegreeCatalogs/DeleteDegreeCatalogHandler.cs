using _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.DegreeCatalogs
{
    public class DeleteDegreeCatalogHandler : IRequestHandler<DeleteDegreeCatalogCommand, Result<object>>
    {
        private readonly IDegreeCatalogRepository degreeCatalogRepository;
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public DeleteDegreeCatalogHandler(IDegreeCatalogRepository degreeCatalogRepository, IStaffCatalogRepository staffCatalogRepository)
        {
            this.degreeCatalogRepository = degreeCatalogRepository;
            this.staffCatalogRepository = staffCatalogRepository;
        }
        public async Task<Result<object>> Handle(DeleteDegreeCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await degreeCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                DegreeCatalog? entity = await degreeCatalogRepository.FindByIdAsync(request.Id);
                if (await staffCatalogRepository.IsExist(x => x.DegreeId == entity.Id))
                    throw new ConflictException("Not delete");
                degreeCatalogRepository.Remove(entity!);
                await degreeCatalogRepository.SaveChangesAsync(cancellationToken);
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