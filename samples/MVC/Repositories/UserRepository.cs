#region

using System;
using JKCore.Repositories.EntityFramework;
using MVC.Data;

#endregion

namespace MVC.Repositories
{
    public class UserRepository : EntityRepository<User, Guid>, IUserRepository
    {
        public UserRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}