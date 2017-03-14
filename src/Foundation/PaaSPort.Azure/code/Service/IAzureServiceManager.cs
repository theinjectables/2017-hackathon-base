using Microsoft.Azure.Management.Fluent;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Foundation.PaaSPort.Azure.Service
{
    /// <summary>
    /// Base type for retrieving and managing the Azure Client service
    /// </summary>
    public interface IAzureServiceManager
    {
        IAzure GetAzureService(IAzureCredentials credentials);
    }
}