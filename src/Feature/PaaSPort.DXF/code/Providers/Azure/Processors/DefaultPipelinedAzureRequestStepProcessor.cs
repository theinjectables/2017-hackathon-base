using Sitecore.Configuration;
using Sitecore.DataExchange;
using Sitecore.Pipelines;
using Sitecore.Services.Core.Diagnostics;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    public class DefaultPipelinedAzureRequestStepProcessor : BasePipelinedAzureServicesRequestStepProcessor
    {
        protected override IPlugin ExecuteServicePipeline(string servicePipelineName,
            BaseAzureServicePipelineArgs servicePipelineArgs, ILogger logger)
        {
            // get the pipeline from the config
            CorePipeline.Run(servicePipelineName, servicePipelineArgs, Settings.GetSetting("PaaSPort.PipelineGroupName"));

            return servicePipelineArgs.GetResult();
        }
    }
}