using Sitecore.DataExchange;
using Sitecore.Pipelines;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Base class for PaaSPort Service Pipeline arguments
    /// </summary>
    public abstract class BaseAzureServicePipelineArgs : RequestPipelineArgs, IAzureServicePipelineArgs
    {
        /// <summary>
        /// Gets the result from the arguments
        /// </summary>
        /// <returns>
        /// The processor's result object as an <seealso cref="IPlugin"/>
        /// </returns>
        public abstract IPlugin GetResult();
    }
}