using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Wards
{
    public class GetDetailWardQuery : IRequest<Result<LocalizationDTO>>
    {
        public string Id { get; set; }
    }
}