namespace BibleStudy.Console.Features.ServiceBus
{
    using System.Threading;
    using Infrastructure;
    using MediatR;
    using Miruken.Callback;
    using Miruken.Concurrency;
    using Miruken.Infrastructure;

    public class ServiceBusHandler : IServiceBus
    {
        private readonly IMediator _mediator;
        private readonly int _timeout;

        private const int DefaultTimeout = 5000; // 5 sec

        public ServiceBusHandler(IConfig config, IMediator mediator)
        {
            _mediator = mediator;
            _timeout  = config.ApiTimeout ?? DefaultTimeout;
        }

        Promise<TResp> IServiceBus.Process<TResp>(IAsyncRequest<TResp> request)
        {
            var options = GetOptions();
            var cancel  = new CancellationTokenSource();
            return (Promise<TResp>) _mediator.SendAsync(request)
                .ToPromise(cancel, ChildCancelMode.Any)
                .Timeout(options?.Timeout ?? _timeout.Millis())
                .Catch((exception, synchronous) =>
                           {
                               var a = exception.ToString();
                               var b = exception;
                           });
        }

        private static ServiceBusOptions GetOptions()
        {
            var composer = HandleMethod.Composer;
            if (composer == null) return null;
            var options = new ServiceBusOptions();
            return composer.Handle(options, true) ? options : null;
        }
    }
}

