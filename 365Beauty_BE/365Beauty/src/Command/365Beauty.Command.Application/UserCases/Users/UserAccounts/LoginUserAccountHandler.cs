using _365Beauty.Command.Application.Commands.Users.UserAccounts;
using _365Beauty.Command.Application.DTOs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace _365Beauty.Command.Application.UserCases.Users.UserAccounts
{
    public class LoginUserAccountHandler : IRequestHandler<LoginUserAccountCommand, Result<LoginUserAccountDTOs>>
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IPasswordHasher<UserAccount> passwordHasher;
        private readonly IJwtService jwtService;

        public LoginUserAccountHandler(IUserAccountRepository userAccountRepository, IUserRoleRepository userRoleRepository, IPasswordHasher<UserAccount> passwordHasher, IJwtService jwtService)
        {
            this.userAccountRepository = userAccountRepository;
            this.userRoleRepository = userRoleRepository;
            this.passwordHasher = passwordHasher;
            this.jwtService = jwtService;
        }
        public async Task<Result<LoginUserAccountDTOs>> Handle(LoginUserAccountCommand request, CancellationToken cancellationToken)
        {
            UserAccount? entity = await userAccountRepository
                .FindSingleAsync(false, true, x => x.Tel == request.Tel, cancellationToken, x => x.UserAccountRoles, x => x.UserInformation!);
            
            if (entity == null || passwordHasher.VerifyHashedPassword(entity, entity.Password!, request.Password!) != PasswordVerificationResult.Success)
                throw new ConflictException(UserAccountConst.LOGIN_FAIL);

            var roleIds = entity.UserAccountRoles?.Select(role => role.RoleId).ToList() ?? new List<int>();
            var roleNames = userRoleRepository.FindAll(false, x => roleIds.Contains(x.Id)).ToList();
            var token = jwtService.GenerateToken(entity, roleNames.Select(x => x.Name).ToList());

            var loginUserAccountDto = new LoginUserAccountDTOs
            {
                Id = entity.Id,
                AuthResults = new AuthResult
                {
                    Token = token,
                    Success = true
                },
                FullName = entity.UserInformation.FirstName + " " + entity.UserInformation.LastName,
                Img = entity.UserInformation.Img,
                Tel = entity.Tel ?? string.Empty,
                Email = entity.UserInformation.Email,
                UserRoles = roleNames
            };

            return Result.Ok(loginUserAccountDto);
        }
    }
}