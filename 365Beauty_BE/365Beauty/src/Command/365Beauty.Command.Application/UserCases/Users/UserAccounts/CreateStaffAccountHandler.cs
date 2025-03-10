using _365Beauty.Command.Application.Commands.Users.UserAccounts;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace _365Beauty.Command.Application.UserCases.Users.UserAccounts
{
    public class CreateStaffAccountHandler : IRequestHandler<CreateStaffAccountCommand, Result<object>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IPasswordHasher<UserAccount> passwordHasher;

        public CreateStaffAccountHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository, 
                                         IUserAccountRepository userAccountRepository,
                                         IStaffCatalogRepository staffCatalogRepository,
                                         IPasswordHasher<UserAccount> passwordHasher)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
            this.userAccountRepository = userAccountRepository;
            this.staffCatalogRepository = staffCatalogRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<Result<object>> Handle(CreateStaffAccountCommand request, CancellationToken cancellationToken)
        {
            var salon = await beautySalonCatalogRepository.FindByIdAsync(request.SalonId);
            var staff = new StaffCatalog
            {
                SalonId = salon.Id,
                FullName = salon.Name,
                Gender = 0,
                DateOfBirth = DateTime.UtcNow,
                Email = salon.Email,
                Tel = salon.Tel,
                Img = salon.Image,
                IsActived = StatusActived.Actived,
            };
            var account = new UserAccount
            {
                Tel = salon.Tel,
                Password = salon.Tel,
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
                staffCatalogRepository.Add(staff);
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
