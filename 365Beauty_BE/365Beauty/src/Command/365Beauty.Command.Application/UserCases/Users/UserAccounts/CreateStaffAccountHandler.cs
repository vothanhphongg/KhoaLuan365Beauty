using _365Beauty.Command.Application.Commands.Users.UserAccounts;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.Security.Principal;
using System.Text;

namespace _365Beauty.Command.Application.UserCases.Users.UserAccounts
{
    public class CreateStaffAccountHandler : IRequestHandler<CreateStaffAccountCommand, Result<object>>
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IPasswordHasher<UserAccount> passwordHasher;

        public CreateStaffAccountHandler(IUserAccountRepository userAccountRepository,
                                         IStaffCatalogRepository staffCatalogRepository,
                                         IPasswordHasher<UserAccount> passwordHasher)
        {
            this.userAccountRepository = userAccountRepository;
            this.staffCatalogRepository = staffCatalogRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<Result<object>> Handle(CreateStaffAccountCommand request, CancellationToken cancellationToken)
        {
            var staff = await staffCatalogRepository.FindByIdAsync(request.StaffId);
            var account = new UserAccount
            {
                Tel = staff.Tel,
                Password = request.Password,
                CreatedDate = DateTime.UtcNow,
                Otp = RandomOtp(),
                IsActived = 1,
                UserAccountRoles = new List<UserAccountRole>()
            };
            UserAccountRole accountRole = new UserAccountRole
            {
                Id = account.Id,
                RoleId = 3
            };
            // Begin transaction
            using var transaction = await userAccountRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                account.Password = passwordHasher.HashPassword(account, account.Password);
                account.UserAccountRoles.Add(accountRole);
                // Add data
                userAccountRepository.Add(account);
                
                await userAccountRepository.SaveChangesAsync(cancellationToken);
                // Save data
                staff.UserId = account.Id;
                staffCatalogRepository.Update(staff);
                await staffCatalogRepository.SaveChangesAsync(cancellationToken);
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
