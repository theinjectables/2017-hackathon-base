using Sitecore.Services.Core.Model;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.PipelineSteps
{
    /// <summary>
    /// Model for the pipeline step used for executing a PaaSPort Service Pipeline
    /// </summary>
    public class AzureServicesRequestStepItemModel : ItemModel
    {
        /// <summary>
        /// Constant value containing the name of the field that points to the source endpoint
        /// </summary>
        public const string EndpointFrom = "EndpointFrom";
    }
}