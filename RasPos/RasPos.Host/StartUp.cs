using Nancy.Owin;
using Owin;

namespace RasPos.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(new NancyOptions());
        }
    }
}