using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public interface IAzureServicePipelineArgs
    {
        IPlugin GetResult();
    }
}