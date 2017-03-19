using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb.Module.PurgeInbox
{
	public class PurgeInboxObserver : IPipelineObserver<OnAfterConfigureQueueManager>
	{
	    private readonly IServiceBusConfiguration _configuration;
	    private readonly ILog _log;

		public PurgeInboxObserver(IServiceBusConfiguration configuration)
		{
            Guard.AgainstNull(configuration, "configuration");

		    _configuration = configuration;
		    _log = Log.For(this);
		}

	    public void Execute(OnAfterConfigureQueueManager pipelineEvent)
		{
			var purge = _configuration.Inbox.WorkQueue as IPurgeQueue;

			if (purge == null)
			{
				_log.Warning(string.Format(PurgeInboxResources.IPurgeQueueNotImplemented, _configuration.Inbox.WorkQueue.GetType().FullName));

				return;
			}

			purge.Purge();
		}
	}
}