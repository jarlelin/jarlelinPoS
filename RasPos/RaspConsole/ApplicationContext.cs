using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaspConsole
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
            StartTime = DateTime.Now;
        }
        public PriceInformation PriceInformation { get; set; }
        public Serilog.ILogger Logger { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan RunningTime
        {
            get
            {
                return DateTime.Now - StartTime;
            }
        }
    }
}
