using Microsoft.Azure.Management.Fluent;
using Sitecore.Common;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    public class AzureServiceContext : Switcher<IAzure, AzureServiceContext>
    {
        public AzureServiceContext(IAzure azureService) : base(azureService)
        {
        }

        public static bool IsConnected => !string.IsNullOrEmpty(CurrentValue?.GetCurrentSubscription().SubscriptionId);
    }
}