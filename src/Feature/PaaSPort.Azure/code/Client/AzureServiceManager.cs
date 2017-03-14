using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using TheInjectables.Foundation.PaaSPort.Azure.Service;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client
{
    /// <summary>
    /// Class for managing the retrieval of the azure service
    /// </summary>
    public class AzureServiceManager : IAzureServiceManager
    {
        /// <summary>
        /// Configures and returns a new instance of the Azure client service with the given <paramref name="credentials"/>
        /// </summary>
        /// <param name="credentials">The credentials to be used for authenticating with the Azure client service</param>
        /// <returns>
        /// An <seealso cref="IAzure"/> type object representing an instance of the Azure client service
        /// </returns>
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