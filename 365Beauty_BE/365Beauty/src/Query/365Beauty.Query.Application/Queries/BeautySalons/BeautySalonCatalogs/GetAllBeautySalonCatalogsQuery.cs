using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonCatalogs
{
    public class GetAllBeautySalonCatalogsQuery : IRequest<Result<List<BeautySalonCatalogWithLocalizationDTO>>>
    {
        public int IsActived { get; set; }
    }
}