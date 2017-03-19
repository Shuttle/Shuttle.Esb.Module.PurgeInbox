using System;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public class PurgeInboxModule
    {
        private readonly PurgeInboxObserver _purgeInboxObserver;
        private readonly string _startupPipelineName = typeof (StartupPipeline).FullName;

        public PurgeInboxModule(IPipelineFactory pipelineFactory, PurgeInboxObserver purgeInboxObserver)
        {
            Guard.AgainstNull(pipelineFactory, "pipelineFactory");
            Guard.AgainstNull(purgeInboxObserver, "purgeInboxObserver");

            _purgeInboxObserver = purgeInboxObserver;

            pipelineFactory.PipelineCreated += PipelineCreated;
        }

        private void PipelineCreated(object sender, PipelineEventArgs e)
        {
            if (!e.Pipeline.GetType().FullName.Equals(_startupPipelineName, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            e.Pipeline.RegisterObserver(_purgeInboxObserver);
        }
    }
}