using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaspConsole
{
    public class ApplicationContextLoggerAgent
    {
        ApplicationContext _context;
        public ApplicationContextLoggerAgent(ApplicationContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            Console.WriteLine("Starting ApplicationContextLogger in seperate task.");

            while (true)
            {
                Run();
                new System.Threading.ManualResetEvent(false).WaitOne(10000);
            }
        }

        public void Run()
        {
            var price = _context.PriceInformation.PriceString;
            _context.Logger.Information("| Price: {price}  | Running {runningTime} |", price, _context.RunningTime.ToString(@"dd\ hh\:mm\:ss"));
        }
    }
}
