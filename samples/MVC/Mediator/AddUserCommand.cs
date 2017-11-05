#region

using JKCore.Mediator.Abstracts;
using MVC.Data;

#endregion

namespace MVC.Mediator
{
    public class AddUserCommand : IMessage<User>
    {
        public string Username { get; set; }

    }
}