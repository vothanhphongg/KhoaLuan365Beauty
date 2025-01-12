using _365Beauty.Command.Application.Commands.BeautySalonCatalogs;
using _365Beauty.Command.Application.Commands.UserAccounts;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Constants;
using _365Beauty.Domain.Entities;
using MediatR;
using System.Text;

namespace _365Beauty.Command.Application.UserCases.UserAccounts
{
    public class CreateUserAccountHandler : IRequestHandler<CreateUserAccountCommand, Result<object>>
    {
        private readonly IUserAccountRepository userAccountRepository;

        public CreateUserAccountHandler(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task<Result<object>> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            UserAccount account = new UserAccount
            {
                Tel = request.Tel,
                Password = request.Password,
                CreatedDate = DateTime.UtcNow,
                Type = false,
                Otp = RandomOtp(),
                IsActived = 0
            };

            UserInformation information = new UserInformation
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                IdCard = request.IdCard,
                Email = request.Email,
                Address = request.Address,
                WardId = 1,
                CreatedDate = DateTime.UtcNow,

            };

            // Begin transaction
            using var transaction = await userAccountRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                account.userInformation = information;
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

        private void Validators(CreateUserAccountCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Tel).NotNullOrEmpty().MaxLength(UserAccountConst.USER_ACCOUNT_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.FirstName).NotNullOrEmpty().MaxLength(UserInformationConst.USER_INFORMATION_FIRST_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.LastName).NotNullOrEmpty().MaxLength(UserInformationConst.USER_INFORMATION_LAST_NAME_MAX_LENGTH);

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
