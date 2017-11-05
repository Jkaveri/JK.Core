#region

using System;
using JKCore.Repositories;
using MVC.Data;

#endregion

namespace MVC.Repositories
{
    public interface IUserRepository : IEntityRepository<User, Guid>
    {
    }
}