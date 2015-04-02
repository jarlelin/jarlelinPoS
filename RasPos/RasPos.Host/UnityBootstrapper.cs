using System;
using System.Collections.Generic;
using Nancy.Bootstrappers.Unity;

namespace RasPos.Host
{
    public class UnityBootstapper : UnityNancyBootstrapper
    {
        private readonly Dictionary<Type, object> _replacementInstances;
    }
}