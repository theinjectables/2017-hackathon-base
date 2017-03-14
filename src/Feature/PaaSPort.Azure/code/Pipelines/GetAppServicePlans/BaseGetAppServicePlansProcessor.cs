using Sitecore.DataExchange.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetAppServicePlans
{
    /// <summary>
    /// Base type for processors of the getAppServicePlans PaaSPort Service Pipeline
    /// </summary>
    public abstract class BaseGetAppServicePlansProcessor :
        BaseAzureServiceProcessor<GetAppServicePlansArgs, IterableDataSettings>
    {
        public abstract override void Process(GetAppServicePlansArgs args);
    }
}