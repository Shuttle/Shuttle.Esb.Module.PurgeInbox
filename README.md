# Purge Inbox

```
PM> Install-Package Shuttle.Esb.Module.PurgeInbox
```

The PurgeInbox module for Shuttle.Esb clears the inbox work queue upon startup.

The module will attach the `PurgeInboxObserver` to the `OnAfterConfigureQueues` event of the `StartupPipeline` and purges the inbox work queue if the relevant queue implementation has implemented the `IPurgeQueue` interface.  If the inbox work queue implementation has *not* implemented the `IPurgeQueue` interface the purge is ignored.

## Configuration

The module may be added using the following `ServiceBusBuilder` extension method:

```
services.AddServiceBus(builder => 
{
	builder.AddPurgeInboxModule();
});
```