using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public class PurgeInboxObserver : IPipelineObserver<OnAfterConfigureQueues>
    {
        private readonly IServiceBusConfiguration _configuration;

        public PurgeInboxObserver(IServiceBusConfiguration configuration)
        {
            Guard.AgainstNull(configuration, nameof(configuration));

            _configuration = configuration;
        }

        public void Execute(OnAfterConfigureQueues pipelineEvent)
        {
            var purge = _configuration.Inbox.WorkQueue as IPurgeQueue;

            if (purge == null)
            {
                return;
            }

            purge.Purge();
        }
    }
}