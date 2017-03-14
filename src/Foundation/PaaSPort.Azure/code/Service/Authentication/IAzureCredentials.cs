namespace TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication
{
    /// <summary>
    /// Interface defining properties necessary in order to authenticate with the Azure Client services
    /// </summary>
    public interface IAzureCredentials
    {
        /// <summary>
        /// Gets or sets ID of the Azure tenant
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// Gets or sets ID of the Azure client
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// Gets or sets ID of the Azure subscription
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// Gets or sets Azure app key
        /// </summary>
        string Key { get; set; }
    }
}