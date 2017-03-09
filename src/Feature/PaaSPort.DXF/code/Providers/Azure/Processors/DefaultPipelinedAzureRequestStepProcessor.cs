using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.Pipelines;
using Sitecore.Services.Core.Diagnostics;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Extensions;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    public class DefaultPipelinedAzureRequestStepProcessor : BasePipelinedAzureServicesRequestStepProcessor
    {
        protected override IPlugin ExecuteServicePipeline(string servicePipelineName, ILogger logger)
        {
            // get the args
            var args = new AzureServicePipelineArgs<IterableDataSettings>();

            // get the pipeline from the config
            CorePipeline.Run(servicePipelineName, args, Sitecore.Configuration.Settings.GetSetting("PaaSPort.PipelineGroupName"));

            return args.Result;
        }
    }
}