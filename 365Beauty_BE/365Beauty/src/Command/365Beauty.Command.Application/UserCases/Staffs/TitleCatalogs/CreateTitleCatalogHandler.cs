using _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.TitleCatalogs
{
    public class CreateTitleCatalogHandler : IRequestHandler<CreateTitleCatalogCommand, Result<object>>
    {
        private readonly ITitleCatalogRepository titleCatalogRepository;

        public CreateTitleCatalogHandler(ITitleCatalogRepository titleCatalogRepository)
        {
            this.titleCatalogRepository = titleCatalogRepository;
        }
        public async Task<Result<object>> Handle(CreateTitleCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            TitleCatalog entity = new TitleCatalog
            {
                Name = request.Name!
            };
            using var transaction = await titleCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                titleCatalogRepository.Add(entity);
                await titleCatalogRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private void Validators(CreateTitleCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).NotNullOrEmpty().MaxLength(TitleCatalogConst.TITLE_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}