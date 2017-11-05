using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JKCore.Modeling;

namespace MVC.Data
{
    public class User:Entity<Guid>, IEntity
    {
        public string Username { get; set; }
    }
}
