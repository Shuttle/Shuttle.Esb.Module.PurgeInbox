using Shuttle.Core.Container;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Module.PurgeInbox
{
	public static class ComponentRegistryExtensions
	{
		public static void RegisterPurgeInbox(this IComponentRegistry registry)
		{
			Guard.AgainstNull(registry, nameof(registry));

			registry.AttemptRegister<PurgeInboxModule>();
			registry.AttemptRegister<PurgeInboxObserver>();
		}
	}
}