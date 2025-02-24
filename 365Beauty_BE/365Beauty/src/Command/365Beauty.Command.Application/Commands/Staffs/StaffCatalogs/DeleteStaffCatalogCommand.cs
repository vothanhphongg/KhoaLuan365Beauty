﻿using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs
{
    public class DeleteStaffCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}