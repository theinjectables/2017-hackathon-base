using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client
{
    public abstract class BaseAzureManager : IAzureManager
    {
        private readonly IAzureCredential _credentials;

        protected BaseAzureManager(IAzureCredential credentials)
        {
            _credentials = credentials;
            AzureSerivce = Azure();
        }

        public bool Connected { get; private set; }

        public IAzure AzureSerivce { get; }

        private IAzure Azure()
        {
            try
            {
                var servicePrincipal = new ServicePrincipalLoginInformation
                {
                    ClientId = _credentials.ClientId,
                    ClientSecret = _credentials.PassPhrase
                };

                var credentials = new AzureCredentials(servicePrincipal, _credentials.TenantId, AzureEnvironment.AzureGlobalCloud);

                var azure = Microsoft.Azure.Management.Fluent.Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithSubscription(_credentials.SubscriptionId);

                Connected = !string.IsNullOrEmpty(azure.GetCurrentSubscription().SubscriptionId);

                return azure;

            }
            catch (Exception)
            {
                Connected = false;
            }

            return null;
        }
    }
}