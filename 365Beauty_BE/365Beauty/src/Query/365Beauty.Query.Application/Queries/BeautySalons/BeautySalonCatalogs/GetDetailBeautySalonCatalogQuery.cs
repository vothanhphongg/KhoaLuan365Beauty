using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using MediatR;

namespace _365Beauty.Query.ApplicationQueries.BeautySalons.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogQuery : IRequest<Result<BeautySalonCatalogFullDTO>>
    {
        public int Id { get; set; }
    }
}