using System;
using System.Threading;
using System.Threading.Tasks;
using RaspPos.BackgroundAgents;
using Serilog;

namespace RasPos.Host
{
    public class BackgroundWorkerProcess: IDisposable
    {
        private ApplicationContext _appContext;
        Task _priceTask;
        Task _appTask;
        CancellationTokenSource _tokenSource;


        public static IDisposable Start(ApplicationContext appContext)
        {
            return new BackgroundWorkerProcess(appContext).Run();
        }

        private BackgroundWorkerProcess(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        private BackgroundWorkerProcess Run()
        {
            _appContext.Logger = new Serilog.LoggerConfiguration()
                                .WriteTo.ColoredConsole()
                                .MinimumLevel.Debug()
                                .CreateLogger();
            _appContext.PriceInformation = new PriceInformation(_appContext.Logger);

            _appContext.Logger.Information(string.Format("Console started on " + Environment.OSVersion.Platform.ToString()));
            _appContext.Logger.Information(string.Format("Environment is  " + System.Globalization.CultureInfo.CurrentCulture.ToString()));


            _tokenSource = new CancellationTokenSource();
            _priceTask = new Task(new PricePollAgent(_appContext.Logger, _appContext.PriceInformation).Run().Execute, _tokenSource.Token);
            _priceTask.Start();
            _appTask = new Task(new ApplicationContextLoggerAgent(_appContext).Execute, _tokenSource.Token);
            _appTask.Start();

            return this;
        }

        public void Dispose()
        {
            if (_appContext != null)
                _appContext.Logger.Information("Shutting down background tasks...");

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