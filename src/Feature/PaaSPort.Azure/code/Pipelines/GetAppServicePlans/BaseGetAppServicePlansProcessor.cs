using Sitecore.DataExchange.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetAppServicePlans
{
    public abstract class BaseGetAppServicePlansProcessor :
        BaseAzureServiceProcessor<GetAppServicePlansArgs, IterableDataSettings>
    {
        public abstract override void Process(GetAppServicePlansArgs args);
    }
}