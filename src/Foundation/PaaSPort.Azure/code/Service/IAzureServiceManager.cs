using Microsoft.Azure.Management.Fluent;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Foundation.PaaSPort.Azure.Service
{
    public interface IAzureServiceManager
    {
        IAzure GetAzureService(IAzureCredential credentials);
    }
}
