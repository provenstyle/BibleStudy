namespace BibleStudy.Console.Features.ServiceBus
{
    using MediatR;
    using Miruken.Callback;
    using Miruken.Concurrency;

    public interface IServiceBus : IResolving
    {
        Promise<TResp> Process<TResp>(IAsyncRequest<TResp> request);
    }
}
