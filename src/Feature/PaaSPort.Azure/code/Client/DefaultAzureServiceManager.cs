using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using TheInjectables.Foundation.PaaSPort.Azure.Service;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client
{
    public class AzureServiceManager : IAzureServiceManager
    {
        public virtual IAzure GetAzureService(IAzureCredentials credentials)
        {
            var servicePrincipal = new ServicePrincipalLoginInformation
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.Key
            };

            var azureCredentials = new AzureCredentials(servicePrincipal, credentials.TenantId,
                AzureEnvironment.AzureGlobalCloud);

            var azure = Microsoft.Azure.Management.Fluent.Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                .Authenticate(azureCredentials)
                .WithSubscription(credentials.SubscriptionId);

            return azure;
        }
    }
}