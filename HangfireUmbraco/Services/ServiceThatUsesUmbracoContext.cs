using Umbraco.Cms.Core.Web;

namespace HangfireUmbraco.Services
{
    public class ServiceThatUsesUmbracoContext
    {
        private readonly IUmbracoContextFactory ctxFactory;

        public ServiceThatUsesUmbracoContext(IUmbracoContextFactory ctxFactory)
        {
            this.ctxFactory = ctxFactory;
        }

        public void DoSomethingWithUmbracoContext()
        {
            using (var ctxRef = ctxFactory.EnsureUmbracoContext())
            {
                var contentAtRoot = ctxRef.UmbracoContext.Content!.GetAtRoot();

                var ids = string.Join(", ", contentAtRoot.Select(x => x.Id));

                Console.WriteLine($"Content IDs at root: {ids}");
            }
        }
    }
}
