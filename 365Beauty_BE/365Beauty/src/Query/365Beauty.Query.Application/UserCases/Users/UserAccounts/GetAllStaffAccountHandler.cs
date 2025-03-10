using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserAccounts;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserAccounts
{
    public class GetAllStaffAccountHandler : IRequestHandler<GetAllStaffAccountQuery, Result<List<StaffAccountDTO>>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public GetAllStaffAccountHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<List<StaffAccountDTO>>> Handle(GetAllStaffAccountQuery request, CancellationToken cancellationToken)
        {
            var salonStaff = beautySalonCatalogRepository
                .FindAll(false, null, x => x.StaffCatalogs!)
                .Select(x => new
                {
                    Salon = x,
                    Staff = x.StaffCatalogs!.FirstOrDefault(s => s.Tel == x.Tel)
                })
                .ToList();

            var entities = salonStaff.Select(x => new StaffAccountDTO
            {
                SalonId = x.Salon.Id,
                Tel = x.Staff?.Tel ?? x.Salon.Tel,
                SalonName = x.Salon.Name,
                Img = x.Salon.Image,
                Email = x.Salon.Email!,
                IsActived = x.Staff != null,
            }).OrderByDescending(x => x.IsActived == false).ToList();


            return await Task.FromResult(Result.Ok(entities));
        }
    }
}
