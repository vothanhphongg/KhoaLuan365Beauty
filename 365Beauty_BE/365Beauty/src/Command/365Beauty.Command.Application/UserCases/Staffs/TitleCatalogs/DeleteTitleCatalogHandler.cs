using _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.TitleCatalogs
{
    public class DeleteTitleCatalogHandler : IRequestHandler<DeleteTitleCatalogCommand, Result<object>>
    {
        private readonly ITitleCatalogRepository titleCatalogRepository;
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public DeleteTitleCatalogHandler(ITitleCatalogRepository titleCatalogRepository, IStaffCatalogRepository staffCatalogRepository)
        {
            this.titleCatalogRepository = titleCatalogRepository;
            this.staffCatalogRepository = staffCatalogRepository;
        }
        public async Task<Result<object>> Handle(DeleteTitleCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await titleCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                TitleCatalog? entity = await titleCatalogRepository.FindByIdAsync(request.Id);
                if (await staffCatalogRepository.IsExist(x => x.TitleId == entity.Id))
                    throw new ConflictException("Not delete");
                titleCatalogRepository.Remove(entity!);
                await titleCatalogRepository.SaveChangesAsync(cancellationToken);
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