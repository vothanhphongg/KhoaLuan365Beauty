using _365Beauty.Command.Application.Commands.Users.UserAccounts;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace _365Beauty.Command.Application.UserCases.Users.UserAccounts
{
    public class RegisterUserAccountHandler : IRequestHandler<RegisterUserAccountCommand, Result<object>>
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IPasswordHasher<UserAccount> passwordHasher;

        public RegisterUserAccountHandler(IUserAccountRepository userAccountRepository, IPasswordHasher<UserAccount> passwordHasher)
        {
            this.userAccountRepository = userAccountRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<Result<object>> Handle(RegisterUserAccountCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            var userAccountExist = await userAccountRepository.IsExist(x => x.Tel == request.Tel);
            if (userAccountExist)
                throw new ConflictException(UserAccountConst.TEL_IS_EXIST);

            if (request.Password != request.ConfirmPassword)
                throw new ConflictException(UserAccountConst.CONFIRM_PASSWORD_NOT_MATCH);
            UserAccount account = new UserAccount
            {
                Tel = request.Tel,
                Password = request.Password,
                CreatedDate = DateTime.UtcNow,
                Otp = RandomOtp(),
                IsActived = 1,
                UserAccountRoles = new List<UserAccountRole>()
            };
            UserInformation information = new UserInformation
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = 0,
                DateOfBirth = new DateTime(2000, 01, 01),
                Email = request.Email,
            };
            UserAccountRole accountRole = new UserAccountRole
            {
                Id = account.Id,
                RoleId = 2
            };
            // Begin transaction
            using var transaction = await userAccountRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                account.UserInformation = information;
                account.Password = passwordHasher.HashPassword(account, account.Password);
                account.UserAccountRoles.Add(accountRole);
                // Add data
                userAccountRepository.Add(account);
                // Save data

                await userAccountRepository.SaveChangesAsync(cancellationToken);
                // Commit transaction
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();
                throw;
            }
        }

        private void Validators(RegisterUserAccountCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Tel).NotNullOrEmpty().MaxLength(UserAccountConst.USER_ACCOUNT_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.FirstName).NotNullOrEmpty().MaxLength(UserInformationConst.USER_INFORMATION_FIRST_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.LastName).NotNullOrEmpty().MaxLength(UserInformationConst.USER_INFORMATION_LAST_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.Password).NotNullOrEmpty().MaxLength(UserAccountConst.USER_ACCOUNT_PASSWORD_MAX_LENGTH);
            validator.RuleFor(x => x.ConfirmPassword).NotNullOrEmpty().MaxLength(UserAccountConst.USER_ACCOUNT_PASSWORD_MAX_LENGTH);
            validator.RuleFor(x => x.Email).NotNullOrEmpty().Email().MaxLength(UserInformationConst.USER_INFORMATION_EMAIL_MAX_LENGTH);
            validator.Validate();
        }
        private string RandomOtp()
        {
            var random = new Random();
            var randomOtp = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                int numberRandom = random.Next(0, 10);
                randomOtp.Append(numberRandom);
            }
            return randomOtp.ToString();
        }
    }
}
