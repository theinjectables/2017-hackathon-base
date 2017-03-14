using System;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.Services.Core.Diagnostics;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Extensions;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Processors
{
    /// <summary>
    /// Base class for a DXF step processor that executes a PaaSPort Service Pipeline
    /// </summary>
    [RequiredEndpointPlugins(typeof(AzureSettings))]
    public abstract class BasePipelinedAzureServicesRequestStepProcessor : BaseReadDataStepProcessor
    {
        /// <summary>
        /// Executes the PaaSPort Service Pipeline with the given name, arguments and logger
        /// </summary>
        /// <param name="servicePipelineName">The name of the PaaSPort Service Pipeline to run</param>
        /// <param name="servicePipelineArgs">The arguments to be passed to the PaaSPort Service Pipeline</param>
        /// <param name="logger">The object used to write messages to the log files</param>
        /// <returns></returns>
        protected abstract IPlugin ExecuteServicePipeline(string servicePipelineName, BaseAzureServicePipelineArgs servicePipelineArgs, ILogger logger);

        /// <summary>
        /// Runs the service pipeline to read the data and then adds the result to the pipeline context
        /// </summary>
        /// <param name="endpoint">The source DXF endpoint</param>
        /// <param name="pipelineStep">The <seealso cref="PipelineStep"/> to process</param>
        /// <param name="pipelineContext">The <seealso cref="PipelineContext"/> in which this step processor runs</param>
        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            if (pipelineStep == null)
                throw new ArgumentNullException(nameof(pipelineStep));
            if (pipelineContext == null)
                throw new ArgumentNullException(nameof(pipelineContext));

            var logger = pipelineContext.PipelineBatchContext.Logger;

            // get the settings from the plugin on the endpoint
            var settings = endpoint.GetAzureSettings();
            if (settings == null)
                return;

            if (string.IsNullOrWhiteSpace(settings.TenantId))
            {
                logger.Error(
                    $"Required setting 'TenantId' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.Key))
            {
                logger.Error(
                    $"Required setting 'Key' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ClientId))
            {
                logger.Error(
                    $"Required setting 'Client' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.SubscriptionId))
            {
                logger.Error(
                    $"Required setting 'Subscription' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServiceManagerConfigurationPath))
            {
                logger.Error(
                    $"Required setting 'ServiceManagerConfigurationPath' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServicePipelineName))
            {
                logger.Error(
                    $"Required setting 'Subscription' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (string.IsNullOrWhiteSpace(settings.ServicePipelineArgsConfigurationPath))
            {
                logger.Error(
                    $"Required setting 'ServicePipelineArgsConfigurationPath' was not set on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (settings.ServiceManager == null)
            {
                logger.Error(
                    $"Type specified for required setting 'ServiceManagerConfigurationPath' on the Endpoint was not found. The `ServiceManager` property was null. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }
            if (settings.ServicePipelineArgs == null)
            {
                logger.Error(
                    $"Type specified for required setting 'ServicePipelineArgsConfigurationPath' on the Endpoint was not found. The `ServicePipelineArgs` property was null. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            // get the azure service from the manager
            var azureService = settings.ServiceManager.GetAzureService(settings);

            // construct context for the service pipeline and run the pipeline
            using (new AzureServiceContext(azureService))
            {
                // execute the pipeline and add the resulting plugin containing the retrieved data to the pipeline context
                var dataPlugin = ExecuteServicePipeline(settings.ServicePipelineName, settings.ServicePipelineArgs,
                    logger);

                //add the plugin to the DXF pipeline context
                pipelineContext.Plugins.Add(dataPlugin);
            }
        }
    }
}