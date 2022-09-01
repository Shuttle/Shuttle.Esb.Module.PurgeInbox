using System;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Module.PurgeInbox
{
    public class PurgeInboxModule
    {
        private readonly PurgeInboxObserver _purgeInboxObserver;
        private readonly Type _startupPipelineType = typeof (StartupPipeline);

        public PurgeInboxModule(IPipelineFactory pipelineFactory, PurgeInboxObserver purgeInboxObserver)
        {
            Guard.AgainstNull(pipelineFactory, nameof(pipelineFactory));
            Guard.AgainstNull(purgeInboxObserver, nameof(purgeInboxObserver));

            _purgeInboxObserver = purgeInboxObserver;

            pipelineFactory.PipelineCreated += PipelineCreated;
        }

        private void PipelineCreated(object sender, PipelineEventArgs e)
        {
            if (e.Pipeline.GetType() != _startupPipelineType)
            {
                return;
            }

            e.Pipeline.RegisterObserver(_purgeInboxObserver);
        }
    }
}