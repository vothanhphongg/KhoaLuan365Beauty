using _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.TitleCatalogs
{
    public class UpdateTitleCatalogHandler : IRequestHandler<UpdateTitleCatalogCommand, Result<object>>
    {
        private readonly ITitleCatalogRepository titleCatalogRepository;

        public UpdateTitleCatalogHandler(ITitleCatalogRepository titleCatalogRepository)
        {
            this.titleCatalogRepository = titleCatalogRepository;
        }
        public async Task<Result<object>> Handle(UpdateTitleCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await titleCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                TitleCatalog? entity = await titleCatalogRepository.FindByIdAsync(request.Id);
                entity!.Update(request.Name);
                titleCatalogRepository.Update(entity);
                await titleCatalogRepository.SaveChangesAsync(cancellationToken);
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
        private void Validators(UpdateTitleCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).MaxLength(TitleCatalogConst.TITLE_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}