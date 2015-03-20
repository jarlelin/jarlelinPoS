using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace RaspConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("Console started on " + Environment.OSVersion.Platform.ToString()));
            Console.WriteLine(string.Format("Environment is  " + System.Globalization.CultureInfo.CurrentCulture.ToString()));
            var appContext = new ApplicationContext();
            appContext.Logger = new Serilog.LoggerConfiguration()
                                            .WriteTo.ColoredConsole()
                                            .CreateLogger();
            appContext.PriceInformation = new PriceInformation(appContext.Logger);


            var priceTask = new Task(new PricePollAgent(appContext.Logger, appContext.PriceInformation).Run().Execute);
            priceTask.Start();
            var appTask = new Task(new ApplicationContextLoggerAgent(appContext).Execute);
            appTask.Start();
            
            
            Console.ReadLine();
            Console.WriteLine("Exiting...");
        }
    }
}
