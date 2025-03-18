using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetAllUserBookingBySalonIdHandler : IRequestHandler<GetAllUserBookingBySalonIdQuery, Result<List<UserBookingSalonDTO>>>
    {
        private readonly IUserBookingRepository userBookingRepository;

        public GetAllUserBookingBySalonIdHandler(IUserBookingRepository userBookingRepository)
        {
            this.userBookingRepository = userBookingRepository;
        }
        public async Task<Result<List<UserBookingSalonDTO>>> Handle(GetAllUserBookingBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var booking = userBookingRepository
                .FindAll(false, x => x.IsActived == request.IsActived && x.Price.IsActived == 1 && (x.BeautySalonService == null || x.BeautySalonService.SalonId == request.SalonId), 
                    x => x.BeautySalonService!, x => x.Time!, x => x.BookingType!, x => x.UserInformation!, x => x.Price!, x => x.StaffCatalog!, x => x.UserAccount!)
                .ToList();

            var entities = booking.Select(x => new UserBookingSalonDTO
            {
                Id = x.Id,
                UserId = x.UserId,
                StaffId = x.StaffId,
                SalonServiceId = x.BeautySalonService.Id,
                UserName = $"{x.UserInformation.FirstName} {x.UserInformation.LastName}",
                UserEmail = x.UserInformation.Email,
                UserTel = x.UserAccount.Tel,
                UserAvatar = x.UserInformation.Img,
                StaffName = x.StaffCatalog?.FullName,                
                SalonServiceName = x.BeautySalonService.Name,
                TimeId = x.TimeId,
                Times = x.Time.Times,
                BookingDate = x.BookingDate,
                BookingTypeName = x.BookingType.Name,
                Price = x.Price.FinalPrice,
                Description = x.Description,
                CreatedDate = x.CreateDate,
                IsActived = x.IsActived,
                Actived = x.IsActived switch
                {
                    UserBookingConst.NOT_CONFIRM => UserBookingConst.STRING_NOT_CONFIRM,
                    UserBookingConst.CONFIRMED => UserBookingConst.STRING_CONFIRMED,
                    UserBookingConst.SUCCESSED => UserBookingConst.STRING_SUCCESSED,
                    UserBookingConst.RATING => UserBookingConst.STRING_RATING,
                    UserBookingConst.CANCEL => UserBookingConst.STRING_CANCEL
                }
            }).ToList();
            return await Task.FromResult(Result.Ok(entities.OrderBy(x => x.BookingDate).ThenBy(x => x.TimeId).ToList()));
        }
    }
}