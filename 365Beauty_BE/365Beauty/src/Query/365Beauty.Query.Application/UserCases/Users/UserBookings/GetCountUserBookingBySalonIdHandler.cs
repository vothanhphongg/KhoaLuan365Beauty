using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetCountUserBookingBySalonIdHandler : IRequestHandler<GetCountUserBookingBySalonIdQuery, Result<List<UserBookingCountDTO>>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public GetCountUserBookingBySalonIdHandler(IUserBookingRepository userBookingRepository,
                                                   IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<List<UserBookingCountDTO>>> Handle(GetCountUserBookingBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var salonServices = beautySalonServiceRepository.FindAll(false,
                x => x.SalonId == request.SalonId && x.IsActived == StatusActived.Actived, x => x.Price!).Where(x => x.Price != null && x.Price.IsActived == StatusActived.Actived).ToList();

            var bookings = userBookingRepository.FindAll(false,
                x => x.BeautySalonService!.SalonId == request.SalonId && x.BookingDate.Month == DateTime.Now.Month &&
                     (x.IsActived == UserBookingConst.SUCCESSED || x.IsActived == UserBookingConst.RATING),
                x => x.BeautySalonService!).ToList();

            var bookingCounts = bookings.GroupBy(x => x.SalonServiceId).ToDictionary(g => g.Key, g => g.Count());

            var result = salonServices.Select(service =>
            {
                bookingCounts.TryGetValue(service.Id, out int count);
                return new UserBookingCountDTO
                {
                    Id = service.Id,
                    Name = service.Name,
                    Count = count,
                    Amount = service.Price.FinalPrice * count
                };
            }).ToList();

            return await Task.FromResult(Result.Ok(result));
        }
    }
}