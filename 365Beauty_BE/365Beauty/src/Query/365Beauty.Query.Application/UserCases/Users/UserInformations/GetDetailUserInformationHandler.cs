using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Localizations;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Application.Queries.Users.UserInformations;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserInformations
{
    public class GetDetailUserInformationHandler : IRequestHandler<GetDetailUserInformationQuery, Result<UserInfomationWithLocalizationDTO>>
    {
        private readonly IUserInformationRepository userInformationRepository;
        private readonly IMediator mediator;

        public GetDetailUserInformationHandler(IUserInformationRepository userInformationRepository, IMediator mediator)
        {
            this.userInformationRepository = userInformationRepository;
            this.mediator = mediator;
        }
        public async Task<Result<UserInfomationWithLocalizationDTO>> Handle(GetDetailUserInformationQuery request, CancellationToken cancellationToken)
        {
            var userinfo = await userInformationRepository.FindSingleAsync(false, true, x => x.UserId == request.UserId);
            Result<LocalizationDTO>? wardResult = null;

            if (userinfo.WardId != null)
            {
                wardResult = await mediator.Send(new GetDetailWardQuery { Id = userinfo.WardId! }, cancellationToken);
            }
            var entity = new UserInfomationWithLocalizationDTO
            {
                FirstName = userinfo.FirstName,
                LastName = userinfo.LastName,
                Gender = userinfo.Gender,
                DateOfBirth = userinfo.DateOfBirth,
                Img = userinfo.Img,
                IdCard = userinfo.IdCard,
                Email = userinfo.Email,
                Address = userinfo.Address,
                UserId = userinfo.UserId,
                ProvinceName = wardResult?.Data?.ProvinceName,
                DistrictName = wardResult?.Data?.DistrictName,
                WardName = wardResult?.Data?.WardName,
            };
            return Result.Ok(entity);
        }
    }
}