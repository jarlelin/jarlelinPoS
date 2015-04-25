using System;
using Nancy.Hosting.Self;
using RaspPos.BackgroundAgents;
using Serilog.Extras.Topshelf;
using Topshelf;
using Topshelf.Configurators;
using Topshelf.Logging;

namespace RasPos.Host
{
    class Program
    {

        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:80");
            var myAppContext = new ApplicationContext("MyContext");
            var backgroundWorker = BackgroundWorkerProcess.Start(myAppContext);
            var bootstrapper = new MyNancyBootstrapper(myAppContext);

            using (var host = new NancyHost(bootstrapper, uri))
            {
                host.Start();

                Console.WriteLine("Host has started.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }

            backgroundWorker.Dispose();


            
        }

    }
}
