using Hangfire;
using HangfireUmbraco.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace HangfireUmbraco.Events
{
    public class RegisterHangfire : INotificationHandler<ContentPublishingNotification>
    {
        public void Handle(ContentPublishingNotification notification)
        {
            RecurringJob.AddOrUpdate<ServiceThatUsesUmbracoContext>(x => x.DoSomethingWithUmbracoContext() , "* * * * *");
        }
    }
}
