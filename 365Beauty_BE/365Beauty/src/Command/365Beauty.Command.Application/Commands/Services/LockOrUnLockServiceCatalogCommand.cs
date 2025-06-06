﻿using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Services
{
    public class LockOrUnLockServiceCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}