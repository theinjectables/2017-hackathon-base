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
using TheInjectables.Foundation.PaaSPort.Abstractions.Client;
using TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    public class RequestAzureResourceGroupsStepProcessor : BaseRequestAzureServicesStepProcessor
    {
        protected override IPlugin ExecuteServicePipeline(string servicePipelineName, ILogger logger)
        {
            // get the args
            var args = new AzureServicePipelineArgs<IterableDataSettings>();

            // get the pipeline from the config
            CorePipeline.Run(servicePipelineName, args, "PaaSPort");

            return args.Result;
        }
    }
}