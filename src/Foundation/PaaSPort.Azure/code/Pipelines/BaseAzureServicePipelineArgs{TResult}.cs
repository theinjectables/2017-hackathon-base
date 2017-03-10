using Sitecore.DataExchange;
using Sitecore.Pipelines;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public abstract class BaseAzureServicePipelineArgs<TResult> : BaseAzureServicePipelineArgs, IAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        public TResult Result { get; set; }

        TResult IAzureServicePipelineArgs<TResult>.GetResult()
        {
            return Result;
        }

        public override IPlugin GetResult()
        {
            return Result;
        }
    }
}