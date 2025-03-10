﻿using _365Beauty.Command.Domain.Entities.Users;

namespace _365Beauty.Command.Domain.Abstractions.Repositories.Users
{
    public interface IUserAccountRepository : IGenericRepository<UserAccount, int>;
}