using Sitecore.DataExchange.Models;
using TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Plugins;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Extensions
{
    /// <summary>
    /// Class containing extension methods for the <seealso cref="Endpoint"/> type
    /// </summary>
    public static class EndpointExtensions
    {
        /// <summary>
        /// Gets the <seealso cref="AzureSettings"/> from the <paramref name="endpoint"/>
        /// </summary>
        /// <param name="endpoint">The endpoint to get the settings from</param>
        /// <returns>
        /// The <seealso cref="AzureSettings"/> plugin object containing the settings for the endpoint
        /// </returns>
        public static AzureSettings GetAzureSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<AzureSettings>();
        }

        /// <summary>
        /// Checks whether or not the given <paramref name="endpoint"/> has an <seealso cref="AzureSettings"/> plugin object
        /// </summary>
        /// <param name="endpoint">The <seealso cref="Endpoint"/> object to check for settings in</param>
        /// <returns>
        /// [True] if the <paramref name="endpoint"/> has an <seealso cref="AzureSettings"/> plugin object; otherwise [False]
        /// </returns>
        public static bool HasAzureSettings(this Endpoint endpoint)
        {
            return endpoint.GetAzureSettings() != null;
        }
    }
}