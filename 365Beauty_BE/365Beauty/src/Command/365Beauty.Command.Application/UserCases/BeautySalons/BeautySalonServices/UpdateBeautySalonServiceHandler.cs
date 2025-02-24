using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class UpdateBeautySalonServiceHandler : IRequestHandler<UpdateBeautySalonServiceCommand, Result<object>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public UpdateBeautySalonServiceHandler(IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<object>> Handle(UpdateBeautySalonServiceCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await beautySalonServiceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await beautySalonServiceRepository.FindByIdAsync(request.Id);
                entity!.Update(request.ServiceId, request.Name, request.Description, request.Image);
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

        private void Validators(UpdateBeautySalonServiceCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).MaxLength(BeautySalonServiceConst.SS_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}