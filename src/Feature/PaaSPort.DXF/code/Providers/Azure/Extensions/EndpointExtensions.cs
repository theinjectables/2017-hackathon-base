using Sitecore.DataExchange.Models;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Extensions
{
    public static class EndpointExtensions
    {
        public static AzureSettings GetAzureSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<AzureSettings>();
        }

        public static bool HasAzureSettings(this Endpoint endpoint)
        {
            return endpoint.GetAzureSettings() != null;
        }
    }
}