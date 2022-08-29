using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPurgeInboxModule(this IServiceCollection services)
        {
            Guard.AgainstNull(services, nameof(services));

            services.TryAddSingleton<PurgeInboxModule, PurgeInboxModule>();
            services.TryAddSingleton<PurgeInboxObserver, PurgeInboxObserver>();

            services.AddPipelineModule<PurgeInboxModule>();

            return services;
        }
    }
}