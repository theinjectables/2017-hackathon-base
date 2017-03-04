namespace TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication
{
    public interface IAzureCredential
    {
        string TenantId { get; set; }
        string ClientId { get; set; }
        string SubscriptionId { get; set; }
        string PassPhrase { get; set; }
    }
}
