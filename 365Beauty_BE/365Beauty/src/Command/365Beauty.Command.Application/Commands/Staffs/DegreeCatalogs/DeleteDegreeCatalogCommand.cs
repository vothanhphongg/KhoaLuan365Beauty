﻿using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs
{
    public class DeleteDegreeCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}