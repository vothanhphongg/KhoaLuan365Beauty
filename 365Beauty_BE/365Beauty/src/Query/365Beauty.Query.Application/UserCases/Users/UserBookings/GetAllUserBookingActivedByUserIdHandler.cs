using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Application_Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetAllUserBookingActivedByUserIdHandler : IRequestHandler<GetAllUserBookingActivedByUserIdQuery, Result<List<UserBookingActivedDTO>>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IMediator mediator;

        public GetAllUserBookingActivedByUserIdHandler(IUserBookingRepository userBookingRepository, 
                                                       IBeautySalonServiceRepository beautySalonServiceRepository,
                                                       IMediator mediator)
        {
            this.userBookingRepository = userBookingRepository;
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.mediator = mediator;
        }
        public async Task<Result<List<UserBookingActivedDTO>>> Handle(GetAllUserBookingActivedByUserIdQuery request, CancellationToken cancellationToken)
        {
            var booking = userBookingRepository.FindAll(false, x => x.UserId == request.UserId && x.IsActived == request.IsActived, x => x.BeautySalonService, x => x.Time, x => x.BookingType).ToList();

            var entities = new List<UserBookingActivedDTO>();

            foreach (var item in booking)
            {
                var service = await beautySalonServiceRepository.FindByIdAsync(item.SalonServiceId, false, true, cancellationToken,
                    x => x.Price, x => x.ServiceCatalog, x => x.SalonCatalog);
                var wardResult = await mediator.Send(new GetDetailWardQuery { Id = service.SalonCatalog.WardId! }, cancellationToken);
                if (service != null)
                {
                    entities.Add(new UserBookingActivedDTO
                    {
                        Id = item.Id,
                        TimeId = item.TimeId,
                        ServiceName = service.ServiceCatalog!.Name,
                        SalonServiceName = service.Name,
                        SalonName = service.SalonCatalog!.Name,
                        SalonServiceImage = service.Image,
                        AddressFullAscending = $" {service.SalonCatalog.Address}, {wardResult.Data.NameAscending}",
                        BookingDate = item.BookingDate,
                        
                        Times = item.Time!.Times,
                        BookingTypeName = item.BookingType!.Name,
                        Price = service.Price!.FinalPrice,
                        IsActived = item.IsActived,
                        Actived = item.IsActived switch
                        {
                            UserBookingConst.NOT_CONFIRM => UserBookingConst.STRING_CANCEL,
                            UserBookingConst.CONFIRMED => UserBookingConst.STRING_CONFIRMED,
                            UserBookingConst.SUCCESSED => UserBookingConst.STRING_SUCCESSED,
                            UserBookingConst.CANCEL => UserBookingConst.STRING_CANCELED
                        }
                    });
                }
            }
            return await Task.FromResult(Result.Ok(entities.OrderBy(x => x.BookingDate).ThenBy(x => x.TimeId).ToList()));
        }
    }
}