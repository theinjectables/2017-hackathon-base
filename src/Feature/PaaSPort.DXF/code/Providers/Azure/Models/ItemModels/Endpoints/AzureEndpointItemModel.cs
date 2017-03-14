using Sitecore.Services.Core.Model;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.Endpoints
{
    /// <summary>
    /// Model for the settings for the Azure endpoint
    /// </summary>
    public class AzureEndpointItemModel : ItemModel
    {
        /// <summary>
        /// Constant value containing the name of the field that holds the Azure Tenant ID
        /// </summary>
        public const string TenantId = "TenantId";
        /// <summary>
        /// Constant value containing the name of the field that holds the Azure App Key
        /// </summary>
        public const string Key = "Key";
        /// <summary>
        /// Constant value containing the name of the field that holds the Azure Client ID
        /// </summary>
        public const string Client = "ClientId";
        /// <summary>
        /// Constant value containing the name of the field that holds the Azure Subscription ID
        /// </summary>
        public const string Subscription = "SubscriptionId";

        /// <summary>
        /// Constant value containing the name of the field that holds the path to the configuration node containing 
        /// service manager settings
        /// </summary>
        public const string ServiceManagerConfigurationPath = "ServiceManagerConfigurationPath";

        /// <summary>
        /// Constant value containing the name of the field that holds the name of the PaaSPort Service Pipeline to run
        /// </summary>
        public const string ServicePipelineName = "ServicePipelineName";
        /// <summary>
        /// Constant value containing the name of the field that holds the path to the configuration node containing 
        /// settings for the arguments to pass to the PaaSPort Service Pipeline
        /// </summary>
        public const string ServicePipelineArgsConfigurationPath = "ServicePipelineArgsConfigurationPath";
    }
}