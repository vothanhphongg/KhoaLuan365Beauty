using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Staffs.TitleCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.TitleCatalogs
{
    public class GetDetailTitleCatalogsHandler : IRequestHandler<GetDetailTitleCatalogQuery, Result<TitleCatalog>>
    {
        private readonly ITitleCatalogRepository titleCatalogRepository;

        public GetDetailTitleCatalogsHandler(ITitleCatalogRepository titleCatalogRepository)
        {
            this.titleCatalogRepository = titleCatalogRepository;
        }

        public async Task<Result<TitleCatalog>> Handle(GetDetailTitleCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await titleCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}