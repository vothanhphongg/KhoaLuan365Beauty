using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetCountUserBookingBySalonServiceIdHandler : IRequestHandler<GetCountUserBookingBySalonServiceIdQuery, Result<UserBookingCountDTO>>
    {
        private readonly IUserBookingRepository userBookingRepository;

        public GetCountUserBookingBySalonServiceIdHandler(IUserBookingRepository userBookingRepository)
        {
            this.userBookingRepository = userBookingRepository;
        }
        public async Task<Result<UserBookingCountDTO>> Handle(GetCountUserBookingBySalonServiceIdQuery request, CancellationToken cancellationToken)
        {
            var booking = userBookingRepository.FindAll(false,
                    x => x.SalonServiceId == request.SalonServiceId &&
                         (x.IsActived == UserBookingConst.SUCCESSED || x.IsActived == UserBookingConst.RATING),
                    x => x.BeautySalonService!)
                    .ToList();

            var entity = new UserBookingCountDTO
            {
                Id = request.SalonServiceId,
                Name = booking.First().BeautySalonService.Name,
                Count = booking.Count()
            };
            return Result.Ok(entity);
        }
    }
}