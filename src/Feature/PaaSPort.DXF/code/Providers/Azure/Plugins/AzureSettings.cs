using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins
{
    public class AzureSettings : Sitecore.DataExchange.IPlugin
    {
        public string TenantId { get; set; }
        public string Key { get; set; }
        public string Client { get; set; }
        public string Subscription { get; set; }

        public string ServiceManagerConfigurationPath { get; set; }
        private IAzureManager _serviceManager;
        public IAzureManager ServiceManager 
            => _serviceManager ??
                (_serviceManager = !string.IsNullOrEmpty(ServiceManagerConfigurationPath)
                    ? Sitecore.Configuration.Factory.CreateObject(ServiceManagerConfigurationPath, true) as IAzureManager
                    : null);

        public AzureSettings()
        {
        }
    }
}
