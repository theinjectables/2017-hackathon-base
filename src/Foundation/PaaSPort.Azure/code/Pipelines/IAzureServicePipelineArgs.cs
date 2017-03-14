using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Base type for the PaaSPort Service Pipeline processor arguments
    /// </summary>
    public interface IAzureServicePipelineArgs
    {
        /// <summary>
        /// Retrievs the result from the processor arguments
        /// </summary>
        /// <returns>
        /// The processor's result as an <seealso cref="IPlugin"/> object
        /// </returns>
        IPlugin GetResult();
    }
}