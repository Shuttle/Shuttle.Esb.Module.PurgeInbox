using Shuttle.Core.Container;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Module.PurgeInbox
{
	public class Bootstrap :
		IComponentRegistryBootstrap,
		IComponentResolverBootstrap
	{
		private static bool _registryBootstrapCalled;
		private static bool _resolverBootstrapCalled;

		public void Register(IComponentRegistry registry)
		{
			Guard.AgainstNull(registry, nameof(registry));

			if (_registryBootstrapCalled)
			{
				return;
			}

			registry.AttemptRegister<PurgeInboxModule>();
			registry.AttemptRegister<PurgeInboxObserver>();

			_registryBootstrapCalled = true;
		}

		public void Resolve(IComponentResolver resolver)
		{
			Guard.AgainstNull(resolver, nameof(resolver));

			if (_resolverBootstrapCalled)
			{
				return;
			}

			resolver.Resolve<PurgeInboxModule>();

			_resolverBootstrapCalled = true;
		}
	}
}