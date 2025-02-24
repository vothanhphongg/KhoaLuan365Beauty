using _365Beauty.Command.Application.Commands.Users.UserImformations;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserImformations
{
    public class UpdateUserInformationHandler : IRequestHandler<UpdateUserInformationCommand, Result<object>>
    {
        private readonly IUserInformationRepository userInformationRepository;

        public UpdateUserInformationHandler(IUserInformationRepository userInformationRepository)
        {
            this.userInformationRepository = userInformationRepository;
        }
        public async Task<Result<object>> Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
        {
            var entity = await userInformationRepository.FindSingleAsync(false, true, x => x.UserId == request.UserId);
            using var transaction = await userInformationRepository.BeginTransactionAsync(cancellationToken);
            try
            {

                entity.Update(request.FirstName, request.LastName, request.Gender, request.DateOfBirth, request.Img,
                              request.IdCard, request.Email, request.Address, request.WardId);

                userInformationRepository.Update(entity);

                await userInformationRepository.SaveChangesAsync(cancellationToken);

                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
