using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServiceWithPriceHandler : IRequestHandler<GetAllBeautySalonServiceWithPriceQuery, Result<List<BeautySalonServiceWithPriceDTO>>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public GetAllBeautySalonServiceWithPriceHandler(IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<List<BeautySalonServiceWithPriceDTO>>> Handle(GetAllBeautySalonServiceWithPriceQuery request, CancellationToken cancellationToken)
        {
            var salonServices = beautySalonServiceRepository.FindAll(false,x => x.IsActived == StatusActived.Actived, x => x.Price!).Where(x => x.Price != null).ToList();
            var entities = salonServices.Select(x => new BeautySalonServiceWithPriceDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                BasePrice = x.Price?.BasePrice ?? 0,
                FinalPrice = x.Price?.FinalPrice ?? 0,
                PrecentDiscount = (x.Price != null && x.Price.BasePrice > 0) ? (int)Math.Round((x.Price.BasePrice - x.Price.FinalPrice) / x.Price.BasePrice * 100): 0
            }).ToList();

            return await Task.FromResult(Result.Ok(entities));
        }
    }
}
