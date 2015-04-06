using System;
using System.Threading;
using System.Threading.Tasks;
using RaspPos.BackgroundAgents;
using Serilog;

namespace RasPos.Host
{
    public class BackgroundWorkerProcess: IDisposable
    {
        Task _priceTask;
        Task _appTask;
        CancellationTokenSource _tokenSource;



        public static IDisposable Start()
        {
            return new BackgroundWorkerProcess();
        }

        public BackgroundWorkerProcess()
        {
            
            var appContext = new ApplicationContext();
            appContext.Logger = new Serilog.LoggerConfiguration()
                                            .WriteTo.ColoredConsole()
                                            .CreateLogger();
            appContext.PriceInformation = new PriceInformation(appContext.Logger);

            appContext.Logger.Information(string.Format("Console started on " + Environment.OSVersion.Platform.ToString()));
            appContext.Logger.Information(string.Format("Environment is  " + System.Globalization.CultureInfo.CurrentCulture.ToString()));


            _tokenSource = new CancellationTokenSource();
            _priceTask = new Task(new PricePollAgent(appContext.Logger, appContext.PriceInformation).Run().Execute, _tokenSource.Token);
            _priceTask.Start();
            _appTask = new Task(new ApplicationContextLoggerAgent(appContext).Execute, _tokenSource.Token);
            _appTask.Start();
        }

        public void Dispose()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
            }
            _priceTask = null;
            _appTask = null;
            _tokenSource = null;
        }
    }
}