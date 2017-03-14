using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Generic base class for PaaSPort Service Pipeline arguments
    /// </summary>
    /// <typeparam name="TResult">Type of the <seealso cref="IPlugin"/> the processor results are stored in</typeparam>
    public abstract class BaseAzureServicePipelineArgs<TResult> : BaseAzureServicePipelineArgs, IAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// Gets the result object
        /// </summary>
        /// <returns>
        /// The result object as a <seealso cref="TResult"/> 
        /// </returns>
        TResult IAzureServicePipelineArgs<TResult>.GetResult()
        {
            return Result;
        }

        /// <summary>
        /// Gets the result object
        /// </summary>
        /// <returns>
        /// The result object as an <seealso cref="IPlugin"/> 
        /// </returns>
        public override IPlugin GetResult()
        {
            return Result;
        }
    }
}