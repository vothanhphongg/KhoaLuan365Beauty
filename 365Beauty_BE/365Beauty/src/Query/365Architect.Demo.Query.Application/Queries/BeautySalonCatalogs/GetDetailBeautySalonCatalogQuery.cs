using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Entities;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogQuery : IRequest<Result<BeautySalonCatalog>>
    {
        public int Id { get; set; }
    }
}