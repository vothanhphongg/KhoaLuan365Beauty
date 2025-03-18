using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetCountUserBookingHandler : IRequestHandler<GetCountUserBookingQuery, Result<List<UserBookingCountDTO>>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IServiceCatalogRepository serviceCatalogRepository;

        public GetCountUserBookingHandler(IUserBookingRepository userBookingRepository,
                                                     IServiceCatalogRepository serviceCatalogRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.serviceCatalogRepository = serviceCatalogRepository;
        }
        public async Task<Result<List<UserBookingCountDTO>>> Handle(GetCountUserBookingQuery request, CancellationToken cancellationToken)
        {
            var salonServices = serviceCatalogRepository.FindAll(false, x => x.IsActived == StatusActived.Actived).ToList();

            var bookings = userBookingRepository.FindAll(false,x => x.IsActived == UserBookingConst.SUCCESSED || x.IsActived == UserBookingConst.RATING,
                x => x.BeautySalonService!).ToList();

            var bookingCounts = bookings
                .GroupBy(x => x.BeautySalonService.ServiceId)
                .ToDictionary(g => g.Key, g => g.Count());

            var result = salonServices.Select(service => new UserBookingCountDTO
            {
                Id = service.Id,
                Name = service.Name,
                Count = bookingCounts.ContainsKey(service.Id) ? bookingCounts[service.Id] : 0 // Nếu không có booking thì gán 0
            }).ToList();

            return await Task.FromResult(Result.Ok(result));
        }
    }
}