using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServiceFullBySalonIdHandler : IRequestHandler<GetAllBeautySalonServiceFullBySalonIdQuery, Result<List<BeautySalonServiceWithPriceAndBookingDTO>>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IBookingRepository bookingRepository;

        public GetAllBeautySalonServiceFullBySalonIdHandler(IBeautySalonServiceRepository beautySalonServiceRepository, IBookingRepository bookingRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result<List<BeautySalonServiceWithPriceAndBookingDTO>>> Handle(GetAllBeautySalonServiceFullBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var salonservices = beautySalonServiceRepository
                .FindAll(false, x => x.SalonId == request.SalonId && x.IsActived == StatusActived.Actived && (x.Price == null || x.Price.IsActived == 1), x => x.Price!)
                .ToList();

            var bookings = bookingRepository.FindAll(false, null, x => x.Times).ToList();

            var entity = salonservices.Select(x => new BeautySalonServiceWithPriceAndBookingDTO
            {
                Id = x.Id,
                SalonId = x.SalonId,
                Name = x.Name,
                Image = x.Image,
                BasePrice = x.Price?.BasePrice,
                FinalPrice = x.Price?.FinalPrice,
                BookingCount = bookings.FirstOrDefault(b => b.SalonServiceId == x.Id)?.Count ?? 0,
                BookingTimes = bookings.Where(b => b.SalonServiceId == x.Id).SelectMany(b => b.Times).Select(t => t.Id).ToList()
            }).ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}