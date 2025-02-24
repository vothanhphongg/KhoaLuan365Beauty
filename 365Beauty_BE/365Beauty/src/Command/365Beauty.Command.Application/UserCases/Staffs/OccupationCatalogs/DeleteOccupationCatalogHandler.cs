using _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.OccupationCatalogs
{
    public class DeleteOccupationCatalogHandler : IRequestHandler<DeleteOccupationCatalogCommand, Result<object>>
    {
        private readonly IOccupationCatalogRepository occupationCatalogRepository;
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public DeleteOccupationCatalogHandler(IOccupationCatalogRepository occupationCatalogRepository, IStaffCatalogRepository staffCatalogRepository)
        {
            this.occupationCatalogRepository = occupationCatalogRepository;
            this.staffCatalogRepository = staffCatalogRepository;
        }
        public async Task<Result<object>> Handle(DeleteOccupationCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await occupationCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                OccupationCatalog? entity = await occupationCatalogRepository.FindByIdAsync(request.Id);
                if (await staffCatalogRepository.IsExist(x => x.OccupationId == entity.Id))
                    throw new ConflictException("Not delete");
                occupationCatalogRepository.Remove(entity!);
                await occupationCatalogRepository.SaveChangesAsync(cancellationToken);
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