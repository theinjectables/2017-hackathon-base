using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.Endpoints;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Converters.Endpoints
{
    public class AzureEndpointConverter : BaseEndpointConverter<ItemModel>
    {
        private static readonly Guid TemplateId = Guid.Parse("{9E41746D-B14C-4FFA-B70B-8F522901CC9E}");
        public AzureEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            //        //
            //        //identify the template an item must be based
            //        //on in order for the converter to be able to
            //        //convert the item
            SupportedTemplateIds.Add(TemplateId);
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            //create the plugin
            var settings = new AzureSettings()
            {
                TenantId = GetStringValue(source, AzureEndpointItemModel.TenantId),
                Key = GetStringValue(source, AzureEndpointItemModel.Key),
                ClientId = GetStringValue(source, AzureEndpointItemModel.Client),
                SubscriptionId = GetStringValue(source, AzureEndpointItemModel.Subscription),
                ServiceManagerConfigurationPath = GetStringValue(source, AzureEndpointItemModel.ServiceManagerConfigurationPath),
                ServicePipelineName = GetStringValue(source, AzureEndpointItemModel.ServicePipelineName),
                ServicePipelineArgsConfigurationPath = GetStringValue(source, AzureEndpointItemModel.ServicePipelineArgsConfigurationPath)
            };

            //add the plugin to the endpoint
            endpoint.Plugins.Add(settings);
        }
    }
}