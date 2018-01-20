using Shuttle.Core.Contract;
using Shuttle.Core.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public class PurgeInboxObserver : IPipelineObserver<OnAfterConfigureQueues>
    {
        private readonly IServiceBusConfiguration _configuration;
        private readonly ILog _log;

        public PurgeInboxObserver(IServiceBusConfiguration configuration)
        {
            Guard.AgainstNull(configuration, nameof(configuration));

            _configuration = configuration;
            _log = Log.For(this);
        }

        public void Execute(OnAfterConfigureQueues pipelineEvent)
        {
            var purge = _configuration.Inbox.WorkQueue as IPurgeQueue;

            if (purge == null)
            {
                _log.Warning(string.Format(Resources.IPurgeQueueNotImplemented, _configuration.Inbox.WorkQueue != null ? _configuration.Inbox.WorkQueue.GetType().FullName : _configuration.Inbox.WorkQueueUri));

                return;
            }

            purge.Purge();
        }
    }
}