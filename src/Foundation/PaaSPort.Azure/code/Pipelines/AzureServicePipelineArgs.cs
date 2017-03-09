using Sitecore.DataExchange;
using Sitecore.Pipelines;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public class AzureServicePipelineArgs<TResult> : ResultPipelineArgs<TResult>, IAzureServicePipelineArgs
        where TResult : IPlugin
    {
    }
}