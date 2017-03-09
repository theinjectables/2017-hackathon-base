using TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client.Authentication
{
    public class AzureCredential : IAzureCredential
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string SubscriptionId { get; set; }
        public string Key { get; set; }
    }
}