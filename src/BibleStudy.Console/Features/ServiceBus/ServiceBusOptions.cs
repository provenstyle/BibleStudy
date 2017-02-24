namespace BibleStudy.Console.Features.ServiceBus
{
    using System;
    using Miruken.Callback;

    public class ServiceBusOptions : CallbackOptions<ServiceBusOptions>
    {
        public TimeSpan? Timeout { get; set; }

        public override void MergeInto(ServiceBusOptions other)
        {
            if (Timeout.HasValue && !other.Timeout.HasValue)
                other.Timeout = Timeout;
        }
    }

    public static class ServiceBusExtensions
    {
        public static IHandler Timeout(this IHandler handler, TimeSpan timeout)
        {
            return handler == null ? null
                 : new OptionsHandler<ServiceBusOptions>(handler, new ServiceBusOptions
                 {
                     Timeout = timeout
                 });
        }
    }
}
