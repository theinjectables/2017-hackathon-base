using Sitecore.DataExchange;
using Sitecore.Pipelines;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public abstract class BaseAzureServicePipelineArgs : RequestPipelineArgs, IAzureServicePipelineArgs
    {
        public abstract IPlugin GetResult();
    }
}