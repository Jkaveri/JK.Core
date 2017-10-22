using JKCore.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Test.Fake.MessageBus
{
    public class FakeMessageBus : IMessageBus
    {
        public Task Publish(string key, object msg)
        {
            return Task.Delay(0);
        }

        public Task Publish<T>(object msg)
        {
            return Task.Delay(0);
        }

        public Task Publish<T>(T msg)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string key, Action<object> handler)
        {
            
        }
    }
}
