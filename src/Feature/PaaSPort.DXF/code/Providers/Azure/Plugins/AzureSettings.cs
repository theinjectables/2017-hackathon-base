using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.DataExchange;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;
using TheInjectables.Foundation.PaaSPort.Azure.Service;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins
{
    public class AzureSettings : Sitecore.DataExchange.IPlugin, IAzureCredential
    {
        public string TenantId { get; set; }
        public string Key { get; set; }
        public string ClientId { get; set; }
        public string SubscriptionId { get; set; }

        public string ServiceManagerConfigurationPath { get; set; }

        private IAzureServiceManager _serviceManager;
        public IAzureServiceManager ServiceManager
            => _serviceManager ?? 
               (_serviceManager = Sitecore.Configuration.Factory.CreateObject(ServiceManagerConfigurationPath, true) as IAzureServiceManager);

        public string ServicePipelineName { get; set; }
        public string ServicePipelineArgsConfigurationPath { get; set; }

        private BaseAzureServicePipelineArgs _servicePipelineArgs;
        public BaseAzureServicePipelineArgs ServicePipelineArgs
            => _servicePipelineArgs ??
               (_servicePipelineArgs = Sitecore.Configuration.Factory.CreateObject(ServicePipelineArgsConfigurationPath, true) as BaseAzureServicePipelineArgs);

        public AzureSettings()
        {
        }
    }
}
