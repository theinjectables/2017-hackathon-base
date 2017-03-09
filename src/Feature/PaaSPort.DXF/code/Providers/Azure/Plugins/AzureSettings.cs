using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins
{
    public class AzureSettings : Sitecore.DataExchange.IPlugin, IAzureCredential
    {
        public string TenantId { get; set; }
        public string Key { get; set; }
        public string ClientId { get; set; }
        public string SubscriptionId { get; set; }

        public string ServiceManagerConfigurationPath { get; set; }

        public IAzureServiceManager ServiceManager
            => Sitecore.Configuration.Factory.CreateObject(ServiceManagerConfigurationPath, true) as IAzureServiceManager;

        public string ServicePipelineName { get; set; }

        public AzureSettings()
        {
        }
    }
}
