using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.TitleCatalogs
{
    public class GetAllTitleCatalogHandler : IRequestHandler<GetAllTitleCatalogQuery, Result<List<TitleCatalog>>>
    {
        private readonly ITitleCatalogRepository titleCatalogRepository;

        public GetAllTitleCatalogHandler(ITitleCatalogRepository titleCatalogRepository)
        {
            this.titleCatalogRepository = titleCatalogRepository;
        }

        public async Task<Result<List<TitleCatalog>>> Handle(GetAllTitleCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = titleCatalogRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}