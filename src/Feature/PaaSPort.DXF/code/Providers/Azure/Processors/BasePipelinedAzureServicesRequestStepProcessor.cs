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
using TheInjectables.Foundation.PaaSPort.Abstractions.Client;
using TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    [RequiredEndpointPlugins(typeof(AzureSettings))]
    public abstract class BasePipelinedAzureServicesRequestStepProcessor : BaseReadDataStepProcessor
    {
        // ReSharper disable once PublicConstructorInAbstractClass
        public BasePipelinedAzureServicesRequestStepProcessor()
        {
        }

        protected abstract IPlugin ExecuteServicePipeline(string servicePipelineName, ILogger logger);

        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (pipelineStep == null)
            {
                throw new ArgumentNullException(nameof(pipelineStep));
            }
            if (pipelineContext == null)
            {
                throw new ArgumentNullException(nameof(pipelineContext));
            }

            var logger = pipelineContext.PipelineBatchContext.Logger;

            // get the settings from the plugin on the endpoint
            var settings = endpoint.GetAzureSettings();
            if (settings == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(settings.TenantId))
            {
                logger.Error($"Required setting 'TenantId' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.Key))
            {
                logger.Error($"Required setting 'Key' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ClientId))
            {
                logger.Error($"Required setting 'Client' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.SubscriptionId))
            {
                logger.Error($"Required setting 'Subscription' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServiceManagerConfigurationPath))
            {
                logger.Error($"Required setting 'ServiceManagerConfigurationPath' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServicePipelineName))
            {
                logger.Error($"Required setting 'Subscription' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (settings.ServiceManager == null)
            {
                logger.Error($"Type specified for required setting 'ServiceManagerConfigurationPath' on the Endpoint was not found. The `ServiceManager` property was null. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            // get the azure service from the manager
            var azureService = settings.ServiceManager.GetAzureService(settings);

            // construct context for the service pipeline and run the pipeline
            using (new AzureServiceContext(azureService))
            {
                // execute the pipeline and add the resulting plugin containing the retrieved data to the pipeline context
                var dataPlugin = ExecuteServicePipeline(settings.ServicePipelineName, logger);

                //add the plugin to the DXF pipeline context
                pipelineContext.Plugins.Add(dataPlugin);
            }
        }
    }
}