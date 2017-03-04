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
using Sitecore.Services.Core.Diagnostics;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Extensions;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    [RequiredEndpointPlugins(typeof(AzureSettings))]
    public class RequestAzureResourceGroupsStepProcessor : BaseRequestAzureServicesStepProcessor
    {
        public RequestAzureResourceGroupsStepProcessor()
        {
        }

        protected override IPlugin ReadDataFromAzureServices(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger, AzureSettings settings)
        {
            // retrieve the data from the service call, and enumerate
            var resourceGroups = settings.ServiceManager.GetResourceGroups();

            // add the retrieved data to a plugin
            var dataPlugin = new IterableDataSettings(resourceGroups);

            logger.Info(
                 $"Resource groups read from Azure services. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");

            return dataPlugin;
        }
    }
}