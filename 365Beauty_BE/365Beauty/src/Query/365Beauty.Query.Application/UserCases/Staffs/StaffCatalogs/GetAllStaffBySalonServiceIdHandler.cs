using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Constants.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.StaffCatalogs
{
    public class GetAllStaffBySalonServiceIdHandler : IRequestHandler<GetAllStaffCatalogByBeautySalonServiceIdQuery, Result<List<StaffCatalogDTO>>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IUserBookingRepository userBookingRepository;

        public GetAllStaffBySalonServiceIdHandler(IStaffCatalogRepository staffCatalogRepository, 
                                                               IBeautySalonServiceRepository beautySalonServiceRepository,
                                                               IUserBookingRepository userBookingRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.userBookingRepository = userBookingRepository;
        }
        public async Task<Result<List<StaffCatalogDTO>>> Handle(GetAllStaffCatalogByBeautySalonServiceIdQuery request, CancellationToken cancellationToken)
        {
            var service = await beautySalonServiceRepository.FindByIdAsync(request.BeautySalonServiceId);

            // Lấy danh sách nhân viên và các thông tin liên quan
            var staffs = staffCatalogRepository.FindAll(false,
                x => x.SalonId == service.SalonId,
                x => x.ServiceCatalogs!,
                x => x.OccupationCatalog!,
                x => x.TitleCatalog!,
                x => x.DegreeCatalog!).ToList();

            // Lấy danh sách booking của user
            var userBooking = userBookingRepository.FindAll(false,
                x => x.SalonServiceId == request.BeautySalonServiceId
                     && x.BookingDate == request.BookingDate
                     && x.TimeId == request.TimeId && x.IsActived != UserBookingConst.CANCEL).ToList();

            // Lọc nhân viên chưa có booking
            var entities = staffs
                .Where(x => x.ServiceCatalogs.Any(sc => sc.Id == service.ServiceId) &&
                            !userBooking.Any(ub => ub.StaffId == x.Id)) // Loại nhân viên đã có booking
                .Select(x => new StaffCatalogDTO
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Tel = x.Tel,
                    OccupationName = x.OccupationCatalog?.Name ?? "Chưa xác định",
                    TitleName = x.TitleCatalog?.Name ?? "Chưa xác định",
                    DegreeName = x.DegreeCatalog?.Name ?? "Chưa xác định",
                    Introduction = x.Introduction,
                    Img = x.Img
                }).ToList();

            return await Task.FromResult(Result.Ok(entities));
        }
    }
}
