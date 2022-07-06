# Hangfire Umbraco Example

A minimal example using Hangfire in Umbraco that:

1. Dynamically schedules tasks based on a notification

    `Startup.cs`:

    ```csharp
    services.AddUmbraco(_env, _config)
      //...
      .AddNotificationHandler<ContentPublishingNotification, RegisterHangfire>
      //...
    ```

    `RegisterHangfire.cs`:
    ```csharp
    RecurringJob.AddOrUpdate<ServiceThatUsesUmbracoContext>(x => x.DoSomethingWithUmbracoContext() , "* * * * *");
    ```

2.  Does something with an UmbracoContext

    `ServiceThatUsesUmbracoContext.cs`:
    ```csharp
    public void DoSomethingWithUmbracoContext()
    {
        using (var ctxRef = ctxFactory.EnsureUmbracoContext())
        {
            var contentAtRoot = ctxRef.UmbracoContext.Content!.GetAtRoot();

            var ids = string.Join(", ", contentAtRoot.Select(x => x.Id));

            Console.WriteLine($"Content IDs at root: {ids}");
        }
    }
    ```

## Testing

1. Clone, and run.
2. In the installer choose a DB type supported by Hangfire (SQL or LocalDb)
3. Publish some content
4. Check it works - in the console, or set a breakpoint.
