using System;
using System.Collections.Generic;
using System.Text;

namespace RaspPos.BackgroundAgents
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
            StartTime = DateTime.Now;
            Products = PurchasableItem.GetGoods();
        }

        public PriceInformation PriceInformation { get; set; }
        public IEnumerable<PurchasableItem> Products { get; set; }


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
