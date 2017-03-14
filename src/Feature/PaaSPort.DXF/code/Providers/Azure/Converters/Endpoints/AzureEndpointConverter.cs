using System;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.Endpoints;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Converters.Endpoints
{
    /// <summary>
    /// Class for converting the Azure Endpoint settings into an <seealso cref="AzureSettings"/> object to be added to 
    /// the <seealso cref="Endpoint"/>
    /// </summary>
    public class AzureEndpointConverter : BaseEndpointConverter<ItemModel>
    {
        /// <summary>
        /// ID of the template that this converter supports
        /// </summary>
        private static readonly Guid TemplateId = Guid.Parse("{9E41746D-B14C-4FFA-B70B-8F522901CC9E}");

        /// <summary>
        /// Creates a new instance of the <seealso cref="AzureEndpointConverter"/> type
        /// </summary>
        /// <param name="repository">The repository of the item models</param>
        public AzureEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            //        //
            //        //identify the template an item must be based
            //        //on in order for the converter to be able to
            //        //convert the item
            SupportedTemplateIds.Add(TemplateId);
        }

        /// <summary>
        /// Converts the Azure Endpoint settings item to an <seealso cref="AzureSettings"/> object and adds 
        /// it to the <paramref name="endpoint"/>'s <seealso cref="Endpoint.Plugins"/>
        /// </summary>
        /// <param name="source">The <seealso cref="ItemModel"/> to convert the settings from</param>
        /// <param name="endpoint">The <seealso cref="Endpoint"/> to add the converted settings to</param>
        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            //create the plugin
            var settings = new AzureSettings
            {
                TenantId = GetStringValue(source, AzureEndpointItemModel.TenantId),
                Key = GetStringValue(source, AzureEndpointItemModel.Key),
                ClientId = GetStringValue(source, AzureEndpointItemModel.Client),
                SubscriptionId = GetStringValue(source, AzureEndpointItemModel.Subscription),
                ServiceManagerConfigurationPath =
                    GetStringValue(source, AzureEndpointItemModel.ServiceManagerConfigurationPath),
                ServicePipelineName = GetStringValue(source, AzureEndpointItemModel.ServicePipelineName),
                ServicePipelineArgsConfigurationPath =
                    GetStringValue(source, AzureEndpointItemModel.ServicePipelineArgsConfigurationPath)
            };

            //add the plugin to the endpoint
            endpoint.Plugins.Add(settings);
        }
    }
}