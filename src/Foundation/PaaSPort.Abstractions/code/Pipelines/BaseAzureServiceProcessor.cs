using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Management.Fluent;
using Sitecore.DataExchange;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines
{
    public abstract class BaseAzureServiceProcessor<TArgs, TResult> : IAzureServiceProcessor<TArgs, TResult>
        where TArgs : AzureServicePipelineArgs<TResult>
        where TResult : IPlugin
    {
        protected virtual IAzure AzureService => AzureServiceContext.CurrentValue;

        public abstract void Process(TArgs args);
    }
}