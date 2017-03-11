

using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client.Authentication
{
    // TODO: delete me
    public class AzureCredentials : IAzureCredentials
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string SubscriptionId { get; set; }
        public string Key { get; set; }
    }
}