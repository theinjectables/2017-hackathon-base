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
    public abstract class BaseRequestAzureServicesStepProcessor : BaseReadDataStepProcessor
    {
        // ReSharper disable once PublicConstructorInAbstractClass
        public BaseRequestAzureServicesStepProcessor()
        {
        }

        protected abstract IPlugin ReadDataFromAzureServices(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger, AzureSettings settings);

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
            if (string.IsNullOrWhiteSpace(settings.Client))
            {
                logger.Error($"Required setting 'Client' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.Subscription))
            {
                logger.Error($"Required setting 'Subscription' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServiceManagerConfigurationPath))
            {
                logger.Error($"Required setting 'ServiceManagerConfigurationPath' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            // this should never be true because we assert when creating the type, but just as a fallback in case things change...
            if (settings.ServiceManager == null)
            {
                logger.Error($"Type specified in configuration node '{settings.ServiceManagerConfigurationPath}' (ServiceManagerConfigurationPath) was not found. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            // get the plugin containing the read data
            var dataPlugin = ReadDataFromAzureServices(endpoint, pipelineStep, pipelineContext, logger, settings);

            //add the plugin to the pipeline context
            pipelineContext.Plugins.Add(dataPlugin);
        }
    }
}