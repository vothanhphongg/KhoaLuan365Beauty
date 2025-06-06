﻿using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.StaffCatalogs
{

    public class LockOrUnLockStaffCatalogHandler : IRequestHandler<LockOrUnLockStaffCatalogCommand, Result<object>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public LockOrUnLockStaffCatalogHandler(IStaffCatalogRepository staffCatalogRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
        }

        public async Task<Result<object>> Handle(LockOrUnLockStaffCatalogCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await staffCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                StaffCatalog? entity = await staffCatalogRepository.FindByIdAsync(request.Id!, true, true, cancellationToken, x => x.StaffServices!);
                if (entity.StaffServices.Any())
                    throw new ConflictException(MessConst.FOREIGN_KEY_EXISTS.FormatMsg(nameof(StaffCatalog)));

                entity.IsActived = entity.IsActived == StatusActived.UnActived ? StatusActived.Actived : StatusActived.UnActived;
                staffCatalogRepository.Update(entity);
                await staffCatalogRepository.SaveChangesAsync(cancellationToken);

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