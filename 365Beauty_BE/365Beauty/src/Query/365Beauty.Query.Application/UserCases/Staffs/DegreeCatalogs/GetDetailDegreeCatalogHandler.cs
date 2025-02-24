using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Staffs.DegreeCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.DegreeCatalogs
{
    public class GetDetailDegreeCatalogsHandler : IRequestHandler<GetDetailDegreeCatalogQuery, Result<DegreeCatalog>>
    {
        private readonly IDegreeCatalogRepository degreeCatalogRepository;

        public GetDetailDegreeCatalogsHandler(IDegreeCatalogRepository degreeCatalogRepository)
        {
            this.degreeCatalogRepository = degreeCatalogRepository;
        }

        public async Task<Result<DegreeCatalog>> Handle(GetDetailDegreeCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await degreeCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}