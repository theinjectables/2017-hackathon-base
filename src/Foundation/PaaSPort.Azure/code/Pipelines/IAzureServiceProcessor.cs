using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Azure.Pipelines
{
    /// <summary>
    /// Base type for PaaSPort Service Pipeline processors
    /// </summary>
    /// <typeparam name="TArgs">The type of the arguments to be passed into the pipeline</typeparam>
    /// <typeparam name="TResult">The type of the IPlugin object containing the results of the processor</typeparam>
    public interface IAzureServiceProcessor<in TArgs, TResult> 
        where TArgs : BaseAzureServicePipelineArgs<TResult>
        where TResult : class, IPlugin
    {
        /// <summary>
        /// Executes the processor using the specified arguments
        /// </summary>
        /// <param name="args">The arguments for the processor</param>
        void Process(TArgs args);
    }
}