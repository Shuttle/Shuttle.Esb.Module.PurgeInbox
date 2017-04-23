using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public class PurgeInboxObserver : IPipelineObserver<OnAfterConfigureQueues>
    {
        private readonly IServiceBusConfiguration _configuration;
        private readonly ILog _log;

        public PurgeInboxObserver(IServiceBusConfiguration configuration)
        {
            Guard.AgainstNull(configuration, "configuration");

            _configuration = configuration;
            _log = Log.For(this);
        }

        public void Execute(OnAfterConfigureQueues pipelineEvent)
        {
            var purge = _configuration.Inbox.WorkQueue as IPurgeQueue;

            if (purge == null)
            {
                _log.Warning(string.Format(PurgeInboxResources.IPurgeQueueNotImplemented, _configuration.Inbox.WorkQueue != null ? _configuration.Inbox.WorkQueue.GetType().FullName : _configuration.Inbox.WorkQueueUri));

                return;
            }

            purge.Purge();
        }
    }
}