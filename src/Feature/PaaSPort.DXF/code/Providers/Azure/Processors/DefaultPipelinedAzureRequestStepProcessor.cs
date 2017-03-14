using Sitecore.Configuration;
using Sitecore.DataExchange;
using Sitecore.Pipelines;
using Sitecore.Services.Core.Diagnostics;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    /// <summary>
    /// Class representing the default pipeline step processor for running PaaSPort Service Pipelines
    /// </summary>
    public class DefaultPipelinedAzureRequestStepProcessor : BasePipelinedAzureServicesRequestStepProcessor
    {
        /// <summary>
        /// Runs the specified PaaSPort Service Pipeline using the specified arguments and returns 
        /// the <seealso cref="IPlugin"/> result object
        /// </summary>
        /// <param name="servicePipelineName">Name of the PaaSPort Service Pipeline to run</param>
        /// <param name="servicePipelineArgs">The arguments to be passed to the PaaSPort Service Pipeline</param>
        /// <param name="logger">The object to be used for writing messages to the log files</param>
        /// <returns></returns>
        protected override IPlugin ExecuteServicePipeline(string servicePipelineName, BaseAzureServicePipelineArgs servicePipelineArgs, ILogger logger)
        {
            // get the pipeline from the config
            CorePipeline.Run(servicePipelineName, servicePipelineArgs, Settings.GetSetting("PaaSPort.PipelineGroupName"));

            return servicePipelineArgs.GetResult();
        }
    }
}