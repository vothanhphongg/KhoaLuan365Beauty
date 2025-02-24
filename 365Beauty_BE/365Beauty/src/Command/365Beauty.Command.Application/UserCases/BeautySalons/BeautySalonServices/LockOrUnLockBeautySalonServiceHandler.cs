using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class LockOrUnLockBeautySalonServiceHandler : IRequestHandler<LockOrUnLockBeautySalonServiceCommand, Result<object>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public LockOrUnLockBeautySalonServiceHandler(IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<object>> Handle(LockOrUnLockBeautySalonServiceCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await beautySalonServiceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await beautySalonServiceRepository.FindByIdAsync(request.Id);
                entity.IsActived = entity.IsActived == StatusActived.UnActived ? StatusActived.Actived : StatusActived.UnActived;
                beautySalonServiceRepository.Update(entity);
                await beautySalonServiceRepository.SaveChangesAsync(cancellationToken);
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

        private void Validators(LockOrUnLockBeautySalonServiceCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Id).NotNull();
            validator.Validate();
        }
    }
}