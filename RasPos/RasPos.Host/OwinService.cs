using System;
using Microsoft.Owin.Hosting;
using Topshelf;
using Topshelf.Hosts;

namespace RasPos.Host
{
    public class OwinService
    {
        private readonly string _port;
        private IDisposable _webApp;
        private IDisposable _backgroundWorker;

        public OwinService(string port)
        {
            _port = port;
        }

        public bool Start(HostControl hostControl)
        {
            var baseUrl = string.Format("http://+:{0}", _port);
            _webApp = WebApp.Start<Startup>(baseUrl);
            _backgroundWorker = new BackgroundWorkerProcess();

            if (hostControl is ConsoleRunHost)
            {
                DisplayConsolePrompt();
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
            if (_backgroundWorker != null)
            {
                _backgroundWorker.Dispose();
                _backgroundWorker = null;
            }

            hostControl.Stop();
            return true;
        }

        private void DisplayConsolePrompt()
        {
            //Console.WriteLine("Running on port {0}", _port);
            //Console.WriteLine("Press enter to exit");
            //Console.ReadLine();
        }
    }
}