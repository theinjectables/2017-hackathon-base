using TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client.Authentication
{
    public class AzureCredential : IAzureCredential
    {
        private string _tenantId;
        private string _clientId;
        private string _subscriptionId;
        private string _passPhrase;

        public AzureCredential()
        {
            
        }

        public AzureCredential(string tenantId, string clientId, string subscriptionId, string passPhrase)
        {
            _tenantId = tenantId;
            _clientId = clientId;
            _subscriptionId = subscriptionId;
            _passPhrase = passPhrase;
        }

        public string TenantId
        {
            get { return _tenantId; }
            set { _tenantId = value; }
        }

        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public string SubscriptionId
        {
            get { return _subscriptionId; }
            set { _subscriptionId = value; }
        }

        public string PassPhrase
        {
            get { return _passPhrase; }
            set { _passPhrase = value; }
        }
    }
}