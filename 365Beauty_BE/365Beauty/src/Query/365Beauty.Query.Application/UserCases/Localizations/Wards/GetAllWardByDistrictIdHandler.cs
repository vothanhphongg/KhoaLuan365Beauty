using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Wards
{
    public class GetAllWardByDistrictIdHandler : IRequestHandler<GetAllWardByDistrictIdQuery, Result<List<Ward>>>
    {
        private readonly IWardRepository wardRepository;

        public GetAllWardByDistrictIdHandler(IWardRepository wardRepository)
        {
            this.wardRepository = wardRepository;
        }

        public async Task<Result<List<Ward>>> Handle(GetAllWardByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            var entity = wardRepository.FindAll(false, x => x.DistrictId == request.DistrictId).ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}