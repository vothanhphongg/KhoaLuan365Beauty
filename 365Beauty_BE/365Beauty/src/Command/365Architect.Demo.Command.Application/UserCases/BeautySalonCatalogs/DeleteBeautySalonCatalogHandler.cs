using _365Beauty.Command.Application.Commands.BeautySalonCatalogs;
using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Entities;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalonCatalogs
{
    public class DeleteBeautySalonCatalogHandler : IRequestHandler<DeleteBeautySalonCatalogCommand, Result<BeautySalonCatalog>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public DeleteBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<BeautySalonCatalog>> Handle(DeleteBeautySalonCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await beautySalonCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await beautySalonCatalogRepository.FindByIdAsync(request.Id);
                entity.IsActived = 0;
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