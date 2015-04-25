using Nancy;
using Nancy.TinyIoc;
using RaspPos.BackgroundAgents;

namespace RasPos.Host
{
    public class MyNancyBootstrapper : DefaultNancyBootstrapper
    {
        private readonly ApplicationContext _myAppContext;

        public MyNancyBootstrapper(ApplicationContext myAppContext)
        {
            _myAppContext = myAppContext;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_myAppContext);
            container.Register(_myAppContext.PriceInformation);

        }
    }
}