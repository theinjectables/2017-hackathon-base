using Sitecore.Configuration;
using Sitecore.DataExchange;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;
using TheInjectables.Foundation.PaaSPort.Azure.Service;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins
{
    public class AzureSettings : IPlugin, IAzureCredentials
    {
        private IAzureServiceManager _serviceManager;

        private BaseAzureServicePipelineArgs _servicePipelineArgs;

        public string ServiceManagerConfigurationPath { get; set; }

        public IAzureServiceManager ServiceManager
            => _serviceManager ??
               (_serviceManager = Factory.CreateObject(ServiceManagerConfigurationPath, true) as IAzureServiceManager);

        public string ServicePipelineName { get; set; }
        public string ServicePipelineArgsConfigurationPath { get; set; }

        public BaseAzureServicePipelineArgs ServicePipelineArgs
            => _servicePipelineArgs ??
               (_servicePipelineArgs =
                   Factory.CreateObject(ServicePipelineArgsConfigurationPath, true) as BaseAzureServicePipelineArgs);

        public string TenantId { get; set; }
        public string Key { get; set; }
        public string ClientId { get; set; }
        public string SubscriptionId { get; set; }
    }
}