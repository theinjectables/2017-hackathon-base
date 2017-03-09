using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Management.Fluent;
using Sitecore.DataExchange;
using Sitecore.Pipelines;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines
{
    public class AzureServicePipelineArgs<TResult> : ResultPipelineArgs<TResult>, IAzureServicePipelineArgs
        where TResult : IPlugin
    {
    }
}