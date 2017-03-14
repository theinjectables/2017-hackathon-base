using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Generic base type for the PaaSPort Service Pipeline processor arguments
    /// </summary>
    /// <typeparam name="TResult">Type of the <seealso cref="IPlugin"/> the processor results are stored in</typeparam>
    public interface IAzureServicePipelineArgs<TResult> : IAzureServicePipelineArgs
        where TResult : class, IPlugin
    {
        /// <summary>
        /// Gets or sets the result
        /// </summary>
        TResult Result { get; set; }

        /// <summary>
        /// Retrievs the result data from the processor
        /// </summary>
        /// <returns>
        /// The processor's result object as a <typeparamref name="TResult"/>
        /// </returns>
        new TResult GetResult();
    }
}