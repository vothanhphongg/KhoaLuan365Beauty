using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Entities;
using _365Beauty.Query.Application.Queries.BeautySalonCatalogs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalonCatalogs
{
    public class GetAllBeautySalonCatalogHandler : IRequestHandler<GetAllBeautySalonCatalogQuery, Result<List<BeautySalonCatalog>>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public GetAllBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }

        public async Task<Result<List<BeautySalonCatalog>>> Handle(GetAllBeautySalonCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = beautySalonCatalogRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}
