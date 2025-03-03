using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Domain.Entities.Users;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Users.UserInformations
{
    public class GetDetailUserInformationQuery :IRequest<Result<UserInfomationWithLocalizationDTO>>
    {
        public int UserId { get; set; }
    }
}