using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public interface IAzureServiceProcessor<in TArgs, TResult> where TArgs : BaseAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        void Process(TArgs args);
    }
}