using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.PipelineSteps;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Converters.PipelineSteps
{
    public class AzureServicesRequestStepConverter : BasePipelineStepConverter<ItemModel>
    {
        private static readonly Guid TemplateId = Guid.Parse("{F36BF39C-2054-41E4-866C-B3F81382838D}");

        public AzureServicesRequestStepConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }

        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            AddEndpointSettings(source, pipelineStep);
        }

        private void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
        {
            var settings = new EndpointSettings();

            var endpointFrom = ConvertReferenceToModel<Endpoint>(source, AzureServicesRequestStepItemModel.EndpointFrom);
            if (endpointFrom != null)
            {
                settings.EndpointFrom = endpointFrom;
            }

            pipelineStep.Plugins.Add(settings);
        }
    }
}