using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client.Authentication
{
    /// <summary>
    /// Class representation of the data necessary to authenticate with the Azure client servoce
    /// </summary>
    public class AzureCredentials : IAzureCredentials
    {
        /// <summary>
        /// Gets or sets ID of the Azure tenant
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets ID of the Azure client
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets ID of the Azure subscription
        /// </summary>
        public string SubscriptionId { get; set; }
        /// <summary>
        /// Gets or sets ID of the Azure app key
        /// </summary>
        public string Key { get; set; }
    }
}