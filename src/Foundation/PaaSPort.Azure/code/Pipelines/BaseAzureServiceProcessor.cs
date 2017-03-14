using Microsoft.Azure.Management.Fluent;
using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Generic base class for a PaaSPort Service Pipeline processor
    /// </summary>
    /// <typeparam name="TArgs">The type of the processor's arguments</typeparam>
    /// <typeparam name="TResult">The type of the processor's result object</typeparam>
    public abstract class BaseAzureServiceProcessor<TArgs, TResult> : IAzureServiceProcessor<TArgs, TResult>
        where TArgs : BaseAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        /// <summary>
        /// Gets the Azure Client service from the current <seealso cref="AzureServiceContext"/>
        /// </summary>
        protected virtual IAzure AzureService => AzureServiceContext.IsConnected ? AzureServiceContext.CurrentValue : null;

        /// <summary>
        /// Executes the processor using the specified arguments
        /// </summary>
        /// <param name="args">The type of the processor arguments</param>
        public abstract void Process(TArgs args);
    }
}