using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServiceBySalonIdHandler : IRequestHandler<GetAllBeautySalonServiceBySalonIdQuery, Result<List<BeautySalonService>>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public GetAllBeautySalonServiceBySalonIdHandler(IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<List<BeautySalonService>>> Handle(GetAllBeautySalonServiceBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var entity = beautySalonServiceRepository.FindAll(false, x => x.SalonId == request.SalonId && x.IsActived == request.IsActived).ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}