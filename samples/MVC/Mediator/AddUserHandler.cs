using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator;
using JKCore.Mediator.Abstracts;
using MVC.Data;
using MVC.Repositories;

namespace MVC.Mediator
{
    public class AddUserHandler : MediatorHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepo;

        public AddUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public override async Task<IMediatorResult<User>> Process(AddUserCommand message, CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = new User
            {
                Username = message.Username
            };

            await _userRepo.InsertAsync(user, cancellationToken);

            return Success(user);
        }
    }
}
