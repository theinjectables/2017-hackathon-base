using Microsoft.Azure.Management.Fluent;
using Sitecore.Common;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Class representation of the context in which a PaaSPort Service Pipeline can run
    /// </summary>
    /// <remarks>
    /// Note that this type is an <seealso cref="System.IDisposable"/> inherits Sitecore's 
    /// <seealso cref="Switcher{TValue,TSwitchType}"/> class. This class may be instantiated 
    /// in a using-statement containing the calls to run one or more PaaSPort Service 
    /// Pipelines.
    /// </remarks>
    public class AzureServiceContext : Switcher<IAzure, AzureServiceContext>
    {
        /// <summary>
        /// Creates a new instance of the <seealso cref="AzureServiceContext"/> type
        /// </summary>
        /// <remarks>
        /// Note that the Azure client service is stored in the <seealso cref="Switcher{TValue,TSwitchType}.CurrentValue"/>
        /// </remarks>
        /// <param name="azureService">The Azure client service to be used for the context</param>
        public AzureServiceContext(IAzure azureService) : base(azureService)
        {
        }

        /// <summary>
        /// Checks whether or not the Azure service is connected
        /// </summary>
        /// <remarks>
        /// Note that the Azure client service is stored in the <seealso cref="Switcher{TValue,TSwitchType}.CurrentValue"/>
        /// </remarks>
        public static bool IsConnected => !string.IsNullOrEmpty(CurrentValue?.GetCurrentSubscription().SubscriptionId);
    }
}