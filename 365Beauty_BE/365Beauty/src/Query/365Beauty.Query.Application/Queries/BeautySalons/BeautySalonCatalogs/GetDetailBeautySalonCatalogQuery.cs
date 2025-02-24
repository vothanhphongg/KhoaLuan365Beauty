using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace _365Beauty.Query.ApplicationQueries.BeautySalons.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogQuery : IRequest<Result<BeautySalonCatalog>>
    {
        public int Id { get; set; }
    }
}