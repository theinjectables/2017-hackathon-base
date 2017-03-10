using Microsoft.Azure.Management.Fluent;
using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public abstract class BaseAzureServiceProcessor<TArgs, TResult> : IAzureServiceProcessor<TArgs, TResult>
        where TArgs : BaseAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        protected virtual IAzure AzureService => AzureServiceContext.CurrentValue;

        public abstract void Process(TArgs args);
    }
}