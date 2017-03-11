using Sitecore.DataExchange.Plugins;
using TheInjectables.Foundation.PaaSPort.Azure.Pipelines;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetResourceGroups
{
    public abstract class BaseGetResourceGroupsProcessor :
        BaseAzureServiceProcessor<GetResourceGroupsArgs, IterableDataSettings>
    {
        public abstract override void Process(GetResourceGroupsArgs args);
    }
}