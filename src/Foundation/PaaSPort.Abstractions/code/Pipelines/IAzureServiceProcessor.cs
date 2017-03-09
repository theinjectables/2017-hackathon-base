using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines
{
    public interface IAzureServiceProcessor<TArgs, TResult> where TArgs : AzureServicePipelineArgs<TResult>
        where TResult : IPlugin
    {
        void Process(TArgs args);
    }
}