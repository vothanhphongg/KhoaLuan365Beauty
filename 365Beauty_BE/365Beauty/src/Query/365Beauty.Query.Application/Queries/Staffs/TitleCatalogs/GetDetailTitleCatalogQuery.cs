using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.TitleCatalogs
{
    public class GetDetailTitleCatalogQuery : IRequest<Result<TitleCatalog>>
    {
        public int Id { get; set; }
    }
}