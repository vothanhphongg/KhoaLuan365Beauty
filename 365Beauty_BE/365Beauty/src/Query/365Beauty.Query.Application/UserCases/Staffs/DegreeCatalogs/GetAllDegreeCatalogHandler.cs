using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.DegreeCatalogs
{
    public class GetAllDegreeCatalogHandler : IRequestHandler<GetAllDegreeCatalogQuery, Result<List<DegreeCatalog>>>
    {
        private readonly IDegreeCatalogRepository degreeCatalogRepository;

        public GetAllDegreeCatalogHandler(IDegreeCatalogRepository degreeCatalogRepository)
        {
            this.degreeCatalogRepository = degreeCatalogRepository;
        }

        public async Task<Result<List<DegreeCatalog>>> Handle(GetAllDegreeCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = degreeCatalogRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}