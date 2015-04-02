using Serilog.Extras.Topshelf;
using Topshelf;
using Topshelf.Logging;

namespace RasPos.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpPort = "80";
            HostLogger.UseLogger(new SerilogHostLoggerConfigurator());

            HostFactory.Run(x =>
            {
                x.Service<OwinService>(s =>
                {
                    s.ConstructUsing(name => new OwinService(httpPort));
                    s.WhenStarted((a, b) => a.Start(b));
                    s.WhenStopped((a, b) => a.Stop(b));
                });
                x.RunAsLocalService();
                x.SetDisplayName("RasPos bitcoin PoS REST API");
                x.SetServiceName("RasPos.Host");
                x.SetDescription("RasPos REST api for kall til point of sale funksjonalitet med bitcoin.");
            });
        }
    }
}
