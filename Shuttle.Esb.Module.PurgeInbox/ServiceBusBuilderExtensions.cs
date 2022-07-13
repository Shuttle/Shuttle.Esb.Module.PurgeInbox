using Microsoft.Extensions.DependencyInjection.Extensions;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public static class ServiceBusBuilderExtensions
    {
        public static ServiceBusBuilder AddPurgeInboxModule(this ServiceBusBuilder serviceBusBuilder)
        {
            Guard.AgainstNull(serviceBusBuilder, nameof(serviceBusBuilder));

            serviceBusBuilder.Services.TryAddSingleton<PurgeInboxModule, PurgeInboxModule>();
            serviceBusBuilder.Services.TryAddSingleton<PurgeInboxObserver, PurgeInboxObserver>();

            serviceBusBuilder.AddModule<PurgeInboxModule>();

            return serviceBusBuilder;
        }
    }
}