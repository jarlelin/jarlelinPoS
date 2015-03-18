using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Serilog;

namespace RaspConsole
{
    public class PricePollAgent
    {
        PriceInformation _priceInformation { get; set; }
        ILogger _logger { get; set; }

        public PricePollAgent(ILogger logger, PriceInformation information) 
        {
            _logger = logger;
            _priceInformation = information;
        }

        public void Execute()
        {
            Console.WriteLine("Starting PricePollAgent in seperate task.");
            while (true)
            {
                Run();
                new System.Threading.ManualResetEvent(false).WaitOne(1000);
            }
        }
          

        public PricePollAgent Run()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://winkdex.com/api/v0/price");

            var task = client.GetAsync("");
            task.Wait();
            var json = task.Result.Content.ReadAsStringAsync().Result;
            var jobj = Newtonsoft.Json.Linq.JObject.Parse(json);
            var price = jobj["price"];

            _priceInformation.Price = int.Parse(price.ToString()) ;
            _logger.Debug("{timestamp} - Price is {price}", DateTime.Now.ToString(), _priceInformation.PriceString);

            return this;
        }
    }
}
