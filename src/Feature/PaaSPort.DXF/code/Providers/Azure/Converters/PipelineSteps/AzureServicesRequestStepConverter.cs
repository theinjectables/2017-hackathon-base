using System;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.PipelineSteps;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Converters.PipelineSteps
{
    /// <summary>
    /// Converter type for converting an <seealso cref="AzureServicesRequestStepItemModel"/> to a plugin to be used during processing
    /// </summary>
    public class AzureServicesRequestStepConverter : BasePipelineStepConverter<ItemModel>
    {
        /// <summary>
        /// ID of the template that this converter supports
        /// </summary>
        private static readonly Guid TemplateId = Guid.Parse("{F36BF39C-2054-41E4-866C-B3F81382838D}");

        /// <summary>
        /// Creates a new instance of the <see cref="AzureServicesRequestStepItemModel"/> type
        /// </summary>
        /// <param name="repository">The repository of the item models</param>
        public AzureServicesRequestStepConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }

        /// <summary>
        /// Creates and adds the <seealso cref="EndpointSettings"/> object to the <paramref name="pipelineStep"/>'s 
        /// <seealso cref="PipelineStep.Plugins"/> property
        /// </summary>
        /// <param name="source">The <seealso cref="ItemModel"/> to convert the settings from</param>
        /// <param name="pipelineStep">The <seealso cref="PipelineStep"/> to add the settings to</param>
        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            AddEndpointSettings(source, pipelineStep);
        }

        /// <summary>
        /// Creates and adds the <seealso cref="EndpointSettings"/> object to the <paramref name="pipelineStep"/>'s 
        /// <seealso cref="PipelineStep.Plugins"/> property
        /// </summary>
        /// <param name="source">The <seealso cref="ItemModel"/> to convert the settings from</param>
        /// <param name="pipelineStep">The <seealso cref="PipelineStep"/> to add the settings to</param>
        private void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
        {
            var settings = new EndpointSettings();

            var endpointFrom = ConvertReferenceToModel<Endpoint>(source, AzureServicesRequestStepItemModel.EndpointFrom);
            if (endpointFrom != null)
                settings.EndpointFrom = endpointFrom;

            pipelineStep.Plugins.Add(settings);
        }
    }
}