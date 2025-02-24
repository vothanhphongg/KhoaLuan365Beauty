﻿using _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.DegreeCatalogs
{
    public class CreateDegreeCatalogHandler : IRequestHandler<CreateDegreeCatalogCommand, Result<object>>
    {
        private readonly IDegreeCatalogRepository degreeCatalogRepository;

        public CreateDegreeCatalogHandler(IDegreeCatalogRepository degreeCatalogRepository)
        {
            this.degreeCatalogRepository = degreeCatalogRepository;
        }
        public async Task<Result<object>> Handle(CreateDegreeCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            DegreeCatalog entity = new DegreeCatalog
            {
                Name = request.Name!
            };
            using var transaction = await degreeCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                degreeCatalogRepository.Add(entity);
                await degreeCatalogRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private void Validators(CreateDegreeCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).NotNullOrEmpty().MaxLength(DegreeCatalogConst.DEGREE_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}