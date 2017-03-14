using Sitecore.Configuration;
using Sitecore.DataExchange;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;
using TheInjectables.Foundation.PaaSPort.Azure.Service;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins
{
    /// <summary>
    /// The <seealso cref="IPlugin"/> object containing the settings for running a PaaSPort Service Pipeline
    /// </summary>
    public class AzureSettings : IPlugin, IAzureCredentials
    {
        private IAzureServiceManager _serviceManager;

        private BaseAzureServicePipelineArgs _servicePipelineArgs;

        /// <summary>
        /// Gets or sets the path to the configuration node defining the type of the service manager
        /// </summary>
        public string ServiceManagerConfigurationPath { get; set; }

        /// <summary>
        /// Gets (or creates and gets) the service manager used to get the Azure client service
        /// </summary>
        public IAzureServiceManager ServiceManager
            => _serviceManager ??
               (_serviceManager = Factory.CreateObject(ServiceManagerConfigurationPath, true) as IAzureServiceManager);

        /// <summary>
        /// Gets or sets the name of the PaaSPort Service Pipeline to be executed
        /// </summary>
        public string ServicePipelineName { get; set; }
        /// <summary>
        /// Gets or sets the path to the configuration node defining the type of the PaaSPort Service Pipeline's arguments
        /// </summary>
        public string ServicePipelineArgsConfigurationPath { get; set; }

        /// <summary>
        /// Gets (or creates and gets) the arguments to be passed to the service pipeline
        /// </summary>
        public BaseAzureServicePipelineArgs ServicePipelineArgs
            => _servicePipelineArgs ??
               (_servicePipelineArgs =
                   Factory.CreateObject(ServicePipelineArgsConfigurationPath, true) as BaseAzureServicePipelineArgs);

        /// <summary>
        /// Gets or sets the <seealso cref="IAzureCredentials.TenantId"/>
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the <seealso cref="IAzureCredentials.Key"/>
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the <seealso cref="IAzureCredentials.ClientId"/>
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the <seealso cref="IAzureCredentials.SubscriptionId"/>
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}