using Serilog;

namespace RaspPos.BackgroundAgents
{
    public class ApplicationContextLoggerAgent
    {
        ApplicationContext _context;
        ILogger _logger;

        public ApplicationContextLoggerAgent(ApplicationContext context)
        {
            _context = context;
            _logger = context.Logger;
        }

        public void Execute()
        {
            _logger.Information("Starting ApplicationContextLogger in seperate task.");

            while (true)
            {
                Run();
                new System.Threading.ManualResetEvent(false).WaitOne(10000);
            }
        }

        public void Run()
        {
            var price = _context.PriceInformation.PriceString;
            var runningTime = _context.RunningTime.ToString(@"dd\ hh\:mm\:ss");
            _context.Logger.Information("| DollarPriceFor100BTC: {price}  | Running {runningTime} |", price, runningTime);
        }
    }
}
