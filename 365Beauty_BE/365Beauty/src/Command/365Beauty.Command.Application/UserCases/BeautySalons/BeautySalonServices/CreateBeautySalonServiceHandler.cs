using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Entities.BeautySalons;
using _365Beauty.Contract.Constants;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class CreateBeautySalonServiceHandler : IRequestHandler<CreateBeautySalonServiceCommand, Result<object>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;

        public CreateBeautySalonServiceHandler(IBeautySalonServiceRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }
        public async Task<Result<object>> Handle(CreateBeautySalonServiceCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            List<BeautySalonService> entities = request.BeautySalonServices.Select(service => new BeautySalonService
            {
                SalonId = request.SalonId,
                ServiceId = service.ServiceId,
                Name = service.Name!,
                Description = service.Description,
                Image = !service.Image.IsNullOrEmpty() ? service.Image : Image.DEFAULT_IMAGE,
                CreatedDate = DateTime.UtcNow,
                IsActived = 1
            }).ToList();

            using var transaction = await beautySalonServiceRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                beautySalonServiceRepository.AddMultiple(entities);
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

        private void Validators(CreateBeautySalonServiceCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.SalonId).NotNull();
            validator.RuleFor(x => x.BeautySalonServices)
                .Must(x => x.All(service => !string.IsNullOrEmpty(service.Name)));
            validator.Validate();
        }
    }
}