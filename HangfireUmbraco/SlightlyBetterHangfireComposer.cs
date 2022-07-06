using Cultiv.Hangfire;
using Umbraco.Cms.Core.Composing;

namespace HangfireUmbraco;

public class SlightlyBetterHangfireComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        HangfireComposer hc = new();

        try
        {
            hc.Compose(builder);
        }
        catch (NotSupportedException ex)
        {
           Console.WriteLine("HangfireComposer didn't like the connection string...");
           Console.WriteLine("Maybe you're trying to use SQLite... that aint gonna work.");
           Console.WriteLine("Maybe you're installing the site, and you don't have a connection string yet?");
           Console.WriteLine("If that's the case, you're going to need to reboot after the install.");
           Console.WriteLine("Sorry.");

           Console.WriteLine("Here's the error:", ex.Message);
        }
    }
}

