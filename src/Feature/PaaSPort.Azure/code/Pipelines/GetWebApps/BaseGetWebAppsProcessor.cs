using Sitecore.DataExchange.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetWebApps
{
    /// <summary>
    /// Base type for processors of the getWebApps PaaSPort Service Pipeline
    /// </summary>
    public abstract class BaseGetWebAppsProcessor : BaseAzureServiceProcessor<GetWebAppsArgs, IterableDataSettings>
    {
        public abstract override void Process(GetWebAppsArgs args);
    }
}