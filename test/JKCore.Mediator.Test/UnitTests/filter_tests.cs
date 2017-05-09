using System;
using System.Collections.Generic;
using System.Threading;
#region

using System.Threading.Tasks;
using FluentAssertions;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;
using JKCore.Mediator.Test.Shared;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

#endregion

namespace JKCore.Mediator.Test.UnitTests
{
    public class filter_tests
    {
        [Fact]
        public async Task filter_should_work()
        {
            var services = new ServiceCollection();
            services.AddMediator()
                .AddHandlersSameAssemblyWith<filter_tests>()
                .AddFilter<AssertionFilter>()
                .AddFilter<AssertionFilter>();

            var sp = services.BuildServiceProvider();

            var mediator = sp.GetService<IMediator>();
            var msg = new ExpectedMessage
            {
                Expected = "test"
            };

            // Actions
            var result = await mediator.Send(msg);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(msg.Expected);
            AssertionFilter.Messages.Should().Contain(msg);
        }

        [Fact]
        public async Task filter_should_run_in_order()
        {
            var containers = new Queue<int>();
            var services = new ServiceCollection();
            services.AddMediator()
                .AddHandlersSameAssemblyWith<filter_tests>()
                .AddFilter((sp) => new Filter1(containers))
                .AddFilter(sp => new Filter2(containers));
            var serviceProvider = services.BuildServiceProvider();

            var mediator = serviceProvider.GetService<IMediator>();
            var msg = new ExpectedMessage
            {
                Expected = "test"
            };

            // Actions
            var result = await mediator.Send(msg);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(msg.Expected);
            containers.Count.Should().Be(2);
            containers.Should().BeInAscendingOrder();
        }

        [Fact]
        public async Task filter_should_run_in_order2()
        {
            var services = new ServiceCollection();
            services.AddMediator()
                .AddHandlersSameAssemblyWith<filter_tests>()
                .AddFilter<Filter3>();

            var serviceProvider = services.BuildServiceProvider();

            var mediator = serviceProvider.GetService<IMediator>();
            var msg = new TestFilterMessage();

            // Actions
            var result = await mediator.Send(msg);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Count.Should().Be(3);
            result.Data.Should().BeInAscendingOrder();
        }

        private class Filter1 : MediatorFilter
        {
            private readonly Queue<int> _containers;

            public Filter1(Queue<int> containers)
            {
                _containers = containers;
            }

            public override Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(TMessage message, Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next, CancellationToken cancellationToken = default(CancellationToken))
            {
                _containers.Enqueue(1);
                return next(message, cancellationToken);
            }
        }

        private class Filter2 : MediatorFilter
        {
            private readonly Queue<int> _containers;

            public Filter2(Queue<int> containers)
            {
                _containers = containers;
            }

            public override Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(TMessage message, Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next, CancellationToken cancellationToken = default(CancellationToken))
            {
                _containers.Enqueue(2);
                return next(message, cancellationToken);
            }
        }

        private class Filter3 : MediatorFilter
        {
            public override async Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(TMessage message, Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next,
                CancellationToken cancellationToken = new CancellationToken())
            {
                var realMsg = message as TestFilterMessage;

                if (realMsg != null)
                {
                    realMsg.Results.Enqueue(1);
                    var result = await next(message, cancellationToken);
                    realMsg.Results.Enqueue(3);
                    return result;
                }

                return await next(message, cancellationToken);
            }
        }

        private class TestFilterMessage : IMessage<Queue<int>>
        {
            public Queue<int> Results { get; } = new Queue<int>();
        }

        private class TestFilterMessageHandler : MediatorHandler<TestFilterMessage, Queue<int>>
        {
            public override Task<IMediatorResult<Queue<int>>> Process(TestFilterMessage message, CancellationToken cancellationToken = new CancellationToken())
            {
                message.Results.Enqueue(2);
                return Task.FromResult(Success(message.Results));
            }
        }
    }

}