using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public interface IAzureServicePipelineArgs<TResult> : IAzureServicePipelineArgs
        where TResult : class, IPlugin
    {
        TResult Result { get; set; }

        new TResult GetResult();
    }
}
